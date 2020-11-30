$(document).ready(function () {
    MQTT();
});

var loadAnalogWrite = false;
var loadCarDoor = false;

function MQTT() {
    function buttonStatusSet(selected, lref, vals) {
        var statusText = "Kapalı";
        if (vals == "1")
            statusText = "Açık";
        else if (vals == "2")
            statusText = "Durduruldu";

        $("#hfValue_" + lref).val(vals);

        $(selected).find("small span").text(statusText);
    };

    function gasStatusSet(selected, lref, vals) {
        var statusText = "Yok";
        var intVal = parseInt(vals);
        $(selected).find(".status .status-title").attr("style", "color:red;");
        if (intVal >= 90)
            statusText = "Acil müdahale gerekli!";
        else if (intVal >= 80)
            statusText = "Ortamda gaz çok yüksek!";
        else if (intVal >= 70)
            statusText = "Ortamda gaz yüksek var!";
        else if (intVal >= 60)
            statusText = "Ortamda gaz var!";
        else if (intVal >= 50)
            statusText = "Ortamda az gaz var!";
        else if (intVal >= 40)
            statusText = "Gaz Algılandı!";
        else
            $(selected).find(".status .status-title").removeAttr("style");

        $("#hfValue_" + lref).val(vals);

        $(selected).find(".status .status-title").text("Durum: " + statusText);
    };

    function temperatureStatusSet(selected, lref, vals) {
        var statusText = "Serin";
        var intVal = parseInt(vals);
        if (intVal <= 18) {
            statusText = "Çok soğuk!";
            $(selected).find(".status .status-title").attr("style", "color:#2567ca");
        }
        else if (intVal > 18 && intVal <= 24)
            statusText = "Normal";
        else if (intVal > 24 && intVal <= 30) {
            statusText = "Sıcak";
            $(selected).find(".status .status-title").attr("style", "color:#f47300");
        }
        else if (intVal > 30 && intVal <= 38) {
            statusText = "Çok sıcak!";
            $(selected).find(".status .status-title").attr("style", "color:#e81313");
        }
        else if (intVal > 38) {
            statusText = "Aşırı sıcak!";
            $(selected).find(".status .status-title").attr("style", "color:red");
        }

        $("#hfValue_" + lref).val(vals);

        $(selected).find(".status .status-title").text("Durum: " + statusText);
    };

    function setComponentValue(lref, deviceType, val) {
        var selectedComponent = $("#dashboard-stat_" + lref);
        var betweenValue = $("#hfBetweenValue_" + lref).val();
        var roomRef = $("#hfRoomRef_" + lref).val();
        var splitVal;
        if (deviceType === "digitalWrite") {
            splitVal = betweenValue.split(','); //deger alanini butonlara at
            $(selectedComponent).find("a.btn-danger").attr("data-value", splitVal[0]);
            $(selectedComponent).find("a.btn-success").attr("data-value", splitVal[1]);
            //degerine gore durumunu ayarla
            buttonStatusSet(selectedComponent, lref, val);
        } else if (deviceType === "Curtain") {
            splitVal = betweenValue.split(','); //deger alanini butonlara at
            $(selectedComponent).find("a.btn-danger").attr("data-value", splitVal[0]);
            $(selectedComponent).find("a.btn-success").attr("data-value", splitVal[1]);
            $(selectedComponent).find("a.btn-info").attr("data-value", splitVal[2]);
            //degerine gore durumunu ayarla
            buttonStatusSet(selectedComponent, lref, val);
        } else if (deviceType === "analogWrite") {
            splitVal = betweenValue.split(','); //deger alanini butonlara at
            if (!loadAnalogWrite) {
                $("#slid_" + lref).noUiSlider({
                    direction: (Metronic.isRTL() ? "rtl" : "ltr"),
                    start: val,
                    connect: "lower",
                    range: {
                        'min': parseInt(splitVal[0]),
                        'max': parseInt(splitVal[1])
                    },
                    format: wNumb({ decimals: 0 })
                });

                $("#slid_" + lref).Link("lower").to($("#hfValue_" + lref));
                $(selectedComponent).find("div a.save").removeAttr("disabled");
                loadAnalogWrite = true;
            } else {
                $("#hfValue_" + lref).val(parseInt(val));
                $("#slid_" + lref).val(parseInt(val));
            }
        } else if (deviceType === "CarDoor") {
            splitVal = betweenValue.split(','); //deger alanini butonlara at
            if (!loadCarDoor) {
                $("#slid_" + lref).noUiSlider({
                    direction: (Metronic.isRTL() ? "rtl" : "ltr"),
                    start: parseInt(val),
                    connect: "lower",
                    range: {
                        'min': parseInt(splitVal[0]),
                        'max': parseInt(splitVal[1])
                    },
                    format: wNumb({ decimals: 0 })
                });

                $("#slid_" + lref).Link("lower").to($("#hfValue_" + lref));
                $(selectedComponent).find("div a.change").removeAttr("disabled");
                loadCarDoor = true;
            } else {
                $("#hfValue_" + lref).val(parseInt(val));
                $("#slid_" + lref).val(parseInt(val));
            }
        } else if (deviceType === "Water") {
            //gelen kaydin degerini al
            var result = "";
            switch (val) {
                case "0":
                    result = "Su algılandı!";
                    $(selectedComponent).find("h4.font-grey-sharp").attr("style", "color:red !important");
                    break;
                case "1":
                    result = "Su algılandı!";
                    $(selectedComponent).find("h4.font-grey-sharp").attr("style", "color:red !important");
                    break;
                case "2":
                    result = "Biraz nem var...";
                    $(selectedComponent).find("h4.font-grey-sharp").removeAttr("style");
                    break;
                case "3":
                    result = "Normal";
                    $(selectedComponent).find("h4.font-grey-sharp").removeAttr("style");
                    break;
                default:
                    result = "-";
            }

            $(selectedComponent).find("h4.font-grey-sharp").text(result);
        } else if (deviceType === "LightSensor") {
            //gelen kaydin degerini al
            var result = "";
            var floatVal = parseFloat(val);
            switch (floatVal) {
                case 2:
                    result = "Ev Karanlık";
                    $(selectedComponent).find("h4.font-grey-sharp").attr("style", "color:red !important");
                    break;
                case 1.8:
                    result = "Hava Aydınlık.";
                    $(selectedComponent).find("h4.font-grey-sharp").removeAttr("style");
                    break;
                default:
                    result = "-";
            }

            $(selectedComponent).find("h4.font-grey-sharp").text(result);
        } else if (deviceType === "Fire") {
            //gelen kaydin degerini al
            var result = "";
            switch (val) {
                case "0":
                    result = "1 M'den yakında yangın var!";
                    $(selectedComponent).find("h4.font-grey-sharp").attr("style", "color:red !important");
                    break;
                case "1":
                    result = "1 M'den civarında yangın var!";
                    $(selectedComponent).find("h4.font-grey-sharp").attr("style", "color:red !important");
                    break;
                case "2":
                    result = "Yangın yok.";
                    $(selectedComponent).find("h4.font-grey-sharp").removeAttr("style");
                    break;
                default:
                    result = "-";
            }

            $(selectedComponent).find("h4.font-grey-sharp").text(result);
        } else if (deviceType === "Action") {
            //gelen kaydin degerini al
            var result = "";
            switch (val) {
                case "0":
                    result = "Hareketlilik yok.";
                    $(selectedComponent).find("h4.font-grey-sharp").removeAttr("style");
                    break;
                case "1":
                    result = "Hareket algılandı!";
                    $(selectedComponent).find("h4.font-grey-sharp").attr("style", "color:red !important");
                    break;
                default:
                    result = "-";
            }

            $(selectedComponent).find("h4.font-grey-sharp").text(result);
        } else if (deviceType === "Gas") {
            $(selectedComponent).find("#progress_" + lref + " span.progress-bar").css("width", (parseInt(val)) + "%");
            $(selectedComponent).find("#progress_" + lref + " span.sr-only").text(val + "% progress");
            $(selectedComponent).find("#status-number_" + lref).text(val + "%");
            $(selectedComponent).find("div a.save").removeAttr("disabled");
            gasStatusSet(selectedComponent, lref, val);
        } else if (deviceType === "Temperature") {
            $(selectedComponent).find("#progress_" + lref + " span.progress-bar").css("width", (parseInt(val)) + "%");
            $(selectedComponent).find("#progress_" + lref + " span.sr-only").text(val + "% progress");
            $(selectedComponent).find("#status-number_" + lref).text(val + "%");
            $(selectedComponent).find("div a.save").removeAttr("disabled");
            temperatureStatusSet(selectedComponent, lref, val);
        }
    };

    //ilk acilista verileri 1 kereligine duzenle
    $(".dashboard-stat2").each(function (index) {
        var lref = $(this).attr("data-LREF");
        var val = $("#hfValue_" + lref).val();
        var deviceType = $("#hfDeviceType_" + lref).val();
        setComponentValue(lref, deviceType, val);
    });

    var topic = $("#hfTopic").val();
    var clientId = $("#hfClientId").val();
    var username = $("#hfUserName").val();

    //MQTT Service
    var mqtt = $.connection.mqtt;
    $.connection.hub.start().done(function () {
        $(".dashboard-stat2 div a.change").click(function () {
            //tiklanan butonu yakala
            //id al
            var lref = $(this).attr("data-lref");
            //butonun tasidigi degeri al
            var value = $(this).attr("data-value");

            //butonlarin hepsini aktif yap
            $(this).parents(".dashboard-stat2").find("div a.change").removeAttr("disabled");
            //tiklanani pasif yap
            $(this).attr("disabled", "disabled");

            //tiklanan butona gore durumu ayarla
            buttonStatusSet($(this).parents(".dashboard-stat2"), lref, value);

            var deviceRef = $("#hfDeviceRef_" + lref).val();
            var pinNr = $("#hfPinNr_" + lref).val();
            var deviceType = $("#hfDeviceType_" + lref).val();
            var roomRef = $("#hfRoomRef_" + lref).val();

            var mergeValue = topic + "/" + roomRef + "/" + deviceRef + "/" + pinNr + "/" + deviceType + "/" + value + "/" + username;
            console.log(mergeValue);
            mqtt.server.mQTTSend(mergeValue);
        });

        $(".dashboard-stat2 div a.save").click(function () {
            var lref = $(this).attr("data-lref");
            console.log(lref);
            //var value = $(this).attr("data-value");

            var deviceRef = $("#hfDeviceRef_" + lref).val();
            var pinNr = $("#hfPinNr_" + lref).val();
            var deviceType = $("#hfDeviceType_" + lref).val();
            var value = $("#hfValue_" + lref).val();
            var roomRef = $("#hfRoomRef_" + lref).val();

            var mergeValue = topic + "/" + roomRef + "/" + deviceRef + "/" + pinNr + "/" + deviceType + "/" + value + "/" + username;
            console.log(mergeValue);
            mqtt.server.mQTTSend(mergeValue);
        });

        $(".dashboard-stat2 div a.read").click(function () {
            var lref = $(this).attr("data-lref");

            var deviceRef = $("#hfDeviceRef_" + lref).val();
            var pinNr = $("#hfPinNr_" + lref).val();
            var deviceType = $("#hfDeviceType_" + lref).val();
            var value = $("#hfValue_" + lref).val();
            var roomRef = $("#hfRoomRef_" + lref).val();

            var mergeValue = topic + "/" + roomRef + "/" + deviceRef + "/" + pinNr + "/" + deviceType + "/" + value + "/" + username;
            console.log(mergeValue);
            mqtt.server.mQTTSend(mergeValue);
        });
    });

    mqtt.client.MQTTReceived = function (result) {
        var message = result.Message;
        var arr = message.split('/');
        var rTopic = result.Topic;
        //var rTopic = result.Topic;
        var rClientId = arr[1];
        console.log(result);
        if (topic == rTopic && clientId == rClientId) {
            //var qosLevel = result.QoSLevel;
            //var retain = result.Retain;
            var rRoomRef = arr[2];
            var rDeviceRef = arr[3];
            var rPinNr = arr[4];
            var rDeviceType = arr[5];
            var rValue = arr[6];
            var rUserName = arr[7];
            var currentUserName = $("#hfUserName").val();
            //ABlok/7584a0766efa4f09a62ed5/1/1/23/digitalWrite/1/ListenerWinForm
            console.log(rTopic + " - " + rClientId + " - " + rRoomRef + " - " + rDeviceRef + " - " + rPinNr + " - " + rDeviceType + " - " + rValue + " - " + rUserName);

            if (rUserName != currentUserName) {
                setComponentValue(rDeviceRef, rDeviceType, rValue);
            }
        }
    };
};