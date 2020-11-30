using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using Model;
using SmartApi.Entity;

namespace SmartApi.Providers
{
    public class SmartService
    {

        private string _userName, _password, _localUserName, _localPassword;
        private static string _ConnectionString;
        SmartDbContext db = new SmartDbContext(_ConnectionString);
        public SmartService(string userName, string password, string ConnectionString)
        {
            _ConnectionString = ConnectionString;

            _userName = userName;
            _password = password;

            _localUserName = userName;
            _localPassword = password;

            //if (userName == _localUserName && password == _localPassword)
            //    HttpContext.Current.Session["admin"] = "admin";
        }

        #region Database process
        public void AdminInsert(ADMIN a)
        {
            db.Admins.Add(a);
            db.SaveChanges();
        }

        public void AdminDelete(int id)
        {
            var admin = db.Admins.FirstOrDefault(a => a.LREF == id);
            db.Admins.Remove(admin);
            db.SaveChanges();
        }

        public void AdminUpdate(ADMIN admin)
        {
            var ad = db.Admins.FirstOrDefault(a => a.LREF == admin.LREF);
            ad.PASSWORD = admin.PASSWORD;
            ad.USERNAME = admin.USERNAME;
            ad.STATUS = admin.STATUS;
            ad.SURNAME = admin.SURNAME;
            ad.DATETIME = admin.DATETIME;
            ad.NAME = admin.NAME;
            db.SaveChanges();
        }

        public ADMIN AdminFirst(int lref)
        {
            var admin = db.Admins.FirstOrDefault(a => a.LREF == lref);
            return admin;
        }

        public IEnumerable<ADMIN> AdminSelect()
        {
            var result = CallWithSessionCheck(() =>
            {
                var admin = from x in db.Admins select x;

                return admin;
            }, _userName, _password);

            return result;
        }

        public void BlokInsert(BLOK b)
        {
            db.Bloks.Add(b);
            db.SaveChanges();
        }

        public void BlokDelete(int id)
        {
            var blok = db.Bloks.FirstOrDefault(a => a.LREF == id);
            db.Bloks.Remove(blok);
            db.SaveChanges();
        }

        public void BlokUpdate(BLOK blok)
        {
            var b = db.Bloks.FirstOrDefault(a => a.LREF == blok.LREF);
            b.NAME = blok.NAME;
            b.STATUS = blok.STATUS;
            db.SaveChanges();
        }

        public BLOK BlokFirst(int lref)
        {
            var blok = db.Bloks.FirstOrDefault(a => a.LREF == lref);
            return blok;
        }

        public IEnumerable<BLOK> BlokSelect()
        {
            var result = CallWithSessionCheck(() =>
            {
                var blok = from x in db.Bloks select x;

                return blok;
            }, _userName, _password);

            return result;
        }

        public IEnumerable<BLOK> BlokActiveSelect()
        {
            var result = CallWithSessionCheck(() =>
            {
                int status = (int)StaticValues.StatusType.Active;
                var blok = from x in db.Bloks where x.STATUS == status select x;
                return blok;
            }, _userName, _password);

            return result;
        }

        public IEnumerable<BLOK> BlokActiveSelectService()
        {
            int status = (int)StaticValues.StatusType.Active;
            var blok = from x in db.Bloks where x.STATUS == status select x;
            return blok;
        }

        public void HomeInsert(HOME home)
        {
            db.Homes.Add(home);
            db.SaveChanges();
        }

        public void HomeDelete(int id)
        {
            var home = db.Homes.FirstOrDefault(a => a.LREF == id);
            db.Homes.Remove(home);
            db.SaveChanges();
        }

        public void HomeUpdate(HOME home)
        {
            var h = db.Homes.FirstOrDefault(a => a.LREF == home.LREF);
            h.NAME = home.NAME;
            h.STATUS = home.STATUS;
            h.BLOKREF = home.BLOKREF;
            h.CLIENTID = home.CLIENTID;
            h.PICTURE = home.PICTURE;
            h.SMARTHOMESTATUS = home.SMARTHOMESTATUS;
            db.SaveChanges();
        }

        public HOME HomeFirst(int lref)
        {
            var home = db.Homes.FirstOrDefault(a => a.LREF == lref);
            return home;
        }

        public HOME HomeFirst(string clientId)
        {
            var home = db.Homes.FirstOrDefault(a => a.CLIENTID == clientId);
            return home;
        }

        public IEnumerable<HOMELIST> HomeSelect()
        {
            string command = "EXEC HOMELIST";
            IEnumerable<HOMELIST> home = db.Database.SqlQuery<HOMELIST>(command, "");

            return home;
        }

        public void RoomInsert(ROOM room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }

        public void RoomDelete(int id)
        {
            var room = db.Rooms.FirstOrDefault(a => a.LREF == id);
            db.Rooms.Remove(room);
            db.SaveChanges();
        }

        public void RoomUpdate(ROOM room)
        {
            var r = db.Rooms.FirstOrDefault(a => a.LREF == room.LREF);
            r.NAME = room.NAME;
            r.STATUS = room.STATUS;
            r.PICTURE = room.PICTURE;
            r.HOMEREF = room.HOMEREF;
            db.SaveChanges();
        }

        public ROOM RoomFirst(int lref)
        {
            var room = db.Rooms.FirstOrDefault(a => a.LREF == lref);
            return room;
        }

        public List<ROOMLIST> RoomSelect()
        {
            string command = "EXEC ROOMLIST";
            IEnumerable<ROOMLIST> room = db.Database.SqlQuery<ROOMLIST>(command, "");

            return room.ToList();
        }

        public List<ROOMLIST> RoomActiveSelect()
        {
            string command = "EXEC ROOMLISTACTIVE";
            int status = (int)StaticValues.StatusType.Active;
            IEnumerable<ROOMLIST> room = db.Database.SqlQuery<ROOMLIST>(command, "");

            return room.ToList();
        }

        public IEnumerable<HOME> HomeActiveSelect()
        {
            var result = CallWithSessionCheck(() =>
            {
                int status = (int)StaticValues.StatusType.Active;
                var home = from x in db.Homes where x.STATUS == status select x;
                return home;
            }, _userName, _password);

            return result;
        }

        public void DeviceInsert(HOMEDEVICETYPE h)
        {
            db.HomeDeviceTypes.Add(h);
            db.SaveChanges();
        }

        public void DeviceDelete(int id)
        {
            var device = db.HomeDeviceTypes.FirstOrDefault(a => a.LREF == id);
            db.HomeDeviceTypes.Remove(device);
            db.SaveChanges();
        }

        public void DeviceUpdate(HOMEDEVICETYPE device)
        {
            var h = db.HomeDeviceTypes.FirstOrDefault(a => a.LREF == device.LREF);
            h.NAME = device.NAME;
            h.STATUS = device.STATUS;
            h.BETWEENVALUE = device.BETWEENVALUE;
            h.DEVICETYPE = device.DEVICETYPE;
            h.PICTURE = device.PICTURE;
            h.PINNR = device.PINNR;
            h.SEQUENCENR = device.SEQUENCENR;
            h.STATUS = device.STATUS;
            db.SaveChanges();
        }

        public HOMEDEVICETYPE DeviceFirst(int lref)
        {
            var home = db.HomeDeviceTypes.FirstOrDefault(a => a.LREF == lref);
            return home;
        }

        public IEnumerable<HOMEDEVICETYPE> DeviceSelect()
        {
            var home = from x in db.HomeDeviceTypes select x;

            return home;
        }

        public IEnumerable<HOMEDEVICETYPE> DeviceActiveSelect()
        {
            int status = (int)StaticValues.StatusType.Active;
            var device = from x in db.HomeDeviceTypes where x.STATUS == status select x;

            return device;
        }

        public void RoomDeviceInsert(ROOMDEVICEVALUE room)
        {
            db.RoomDeviceValues.Add(room);
            db.SaveChanges();
        }

        public void RoomDeviceDelete(int id)
        {
            var room = db.RoomDeviceValues.FirstOrDefault(a => a.LREF == id);
            db.RoomDeviceValues.Remove(room);
            db.SaveChanges();
        }

        public void RoomDeviceUpdate(ROOMDEVICEVALUE room)
        {
            var r = db.RoomDeviceValues.FirstOrDefault(a => a.LREF == room.LREF);
            r.VALUE = room.VALUE;
            r.STATUS = room.STATUS;
            r.DEVICEREF = room.DEVICEREF;
            r.ROOMREF = room.ROOMREF;
            db.SaveChanges();
        }

        public ROOMDEVICEVALUE RoomDeviceFirst(int lref)
        {
            var room = db.RoomDeviceValues.FirstOrDefault(a => a.LREF == lref);
            return room;
        }

        public IEnumerable<ROOMDEVICEVALUE> RoomDeviceSelect()
        {
            var room = from x in db.RoomDeviceValues select x;

            return room;
        }

        public IEnumerable<ROOMDEVICELIST> RoomDeviceList()
        {
            string command = "EXEC ROOMDEVICELIST";
            IEnumerable<ROOMDEVICELIST> room = db.Database.SqlQuery<ROOMDEVICELIST>(command, "");

            return room;
        }

        public void UserInsert(USER u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UserDelete(int id)
        {
            var user = db.Users.FirstOrDefault(a => a.LREF == id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void UserUpdate(USER user)
        {
            var u = db.Users.FirstOrDefault(a => a.LREF == user.LREF);
            u.NAME = user.NAME;
            u.BIRTHDATE = user.BIRTHDATE;
            u.EMAIL = user.EMAIL;
            u.GSMNR = user.GSMNR;
            u.PASSWORD2 = user.PASSWORD2;
            u.PASSWORD = user.PASSWORD;
            u.USERNAME = user.USERNAME;
            u.STATUS = user.STATUS;
            u.HOMECLIENTID = user.HOMECLIENTID;
            u.SMARTHOMESTATUS = user.SMARTHOMESTATUS;
            u.SURNAME = user.SURNAME;
            u.USERTYPE = user.USERTYPE;
            db.SaveChanges();
        }

        public USER UserFirst(int lref)
        {
            var user = db.Users.FirstOrDefault(a => a.LREF == lref);
            return user;
        }

        public USER UserPageFirst(string clientId, int lref)
        {
            var user = db.Users.FirstOrDefault(a => a.LREF == lref && a.HOMECLIENTID == clientId);
            return user;
        }

        public IEnumerable<USERLIST> UserSelect()
        {
            string command = "EXEC USERLIST";
            IEnumerable<USERLIST> user = db.Database.SqlQuery<USERLIST>(command, "");

            return user;
        }

        public IEnumerable<USERLIST> UserPageSelect(string clientId)
        {
            string command = string.Format("EXEC USERPAGELIST '{0}'", clientId);
            IEnumerable<USERLIST> user = db.Database.SqlQuery<USERLIST>(command, "");

            return user;
        }

        public IEnumerable<GETHOMESTATUS> GetHomeStatus(string clientId)
        {
            string command = string.Format("EXEC GETHOMESTATUS '{0}'", clientId);
            var device = db.Database.SqlQuery<GETHOMESTATUS>(command, "");

            return device;
        }

        public RoomValueDto GetRoomDeviceStatus(string clientId, int roomRef)
        {
            string command = string.Format("EXEC GETROOMDEVICESTATE '{0}', {1}", clientId, roomRef);
            var device = db.Database.SqlQuery<GETROOMDEVICESTATE>(command, "");

            var room = db.Rooms.FirstOrDefault(r => r.LREF == roomRef);

            var result = new RoomValueDto
            {
                Room = new RoomDto
                {
                    Lref = room.LREF,
                    Name = room.NAME,
                    Picture = room.PICTURE
                },
                DeviceValue = device.Select(dev => new RoomDeviceValueDto
                {
                    RoomRef = roomRef,
                    DeviceType = dev.DEVICETYPE,
                    Lref = dev.LREF,
                    BetweenValue = dev.BETWEENVALUE,
                    DeviceName = dev.DEVICENAME,
                    DeviceRef = dev.DEVICEREF,
                    PinNr = dev.PINNR,
                    UpdateTime = dev.UPDATETIME,
                    Value = dev.VALUE
                })
            };

            return result;
        }
        #endregion

        #region Admin process
        public UserDto AdminLogin(string userName, string password)
        {
            var admin = db.Admins.FirstOrDefault(a => a.USERNAME == userName && a.PASSWORD == password);
            if (admin != null)
            {
                var a = new UserDto
                {
                    Lref = admin.LREF,
                    Name = admin.NAME,
                    Surname = admin.SURNAME,
                    Username = admin.USERNAME
                };

                HttpContext.Current.Session["admin"] = admin;

                return a;
            }
            else
                return null;
        }
        #endregion

        #region User Process
        public UserDto UserLogin(string userName, string password)
        {
            var command = string.Format("EXEC LOGINUSER '{0}', {1}", userName, password);
            var user = db.Database.SqlQuery<LOGINUSER>(command, "");

            var userDetail = user.Select(u => new UserDto
            {
                Topic = u.TOPIC,
                SmartHomeStatus = u.SMARTHOMESTATUS,
                Lref = u.LREF,
                HomeClientId = u.HOMECLIENTID,
                Name = u.NAME,
                Surname = u.SURNAME,
                Username = u.USERNAME,
                UserType = u.USERTYPE
            }).FirstOrDefault();

            HttpContext.Current.Session["user"] = userDetail;

            return userDetail;
        }

        public HomeRoomsDto RoomList(string homeClientId)
        {
            var result = CallWithSessionCheck(() =>
            {
                var home = db.Homes.FirstOrDefault(a => a.CLIENTID == homeClientId);
                if (home == null)
                    return null;

                int homeRef = home.LREF;
                var rooms = db.Rooms.Where(room => room.HOMEREF == homeRef && room.STATUS == (int)StaticValues.StatusType.Active);
                var homeRoomList = new HomeRoomsDto
                {
                    Home = new HomeDto
                    {
                        Lref = home.LREF,
                        Name = home.NAME,
                        BlokRef = home.BLOKREF,
                        ClientId = home.CLIENTID,
                        Description = ""
                    },
                    Rooms = rooms.Select(room => new RoomDto
                    {
                        Lref = room.LREF,
                        Name = room.NAME,
                        Picture = room.PICTURE
                    })
                };

                return homeRoomList;
            }, _userName, _password);

            return result;
        }

        private RoomDto GetRoom(int lref)
        {
            var getRoom = db.Rooms.FirstOrDefault(a => a.LREF == lref);
            var room = new RoomDto
            {
                Lref = getRoom.LREF,
                Name = getRoom.NAME,
                Picture = getRoom.PICTURE
            };

            return room;
        }

        public RoomDeviceDto RoomDevices(string clientRef, int roomRef)
        {
            var result = CallWithSessionCheck(() =>
            {
                string command = string.Format("EXEC _ROOMDEVICELIST {0}, '{1}'", roomRef, clientRef);
                var devices = db.Database.SqlQuery<DeviceDto>(command, "");
                var room = this.GetRoom(roomRef);
                var roomDevice = new RoomDeviceDto
                {
                    Room = room,
                    Devices = devices
                };

                return roomDevice;
            }, _userName, _password);

            return result;
        }

        #endregion

        #region Device Process
        public ROOMDEVICEVALUE SetDeviceSetting(int roomRef, int deviceRef, int value)
        {
            var device = db.RoomDeviceValues.FirstOrDefault(d => d.DEVICEREF == deviceRef && d.ROOMREF == roomRef);
            if (device != null)
            {
                device.VALUE = value;
                //device.USERREF = user.Lref;
                device.UPDATETIME = DateTime.Now;
                db.SaveChanges();
            }

            return device;
        }

        public IEnumerable<GETHOMEDETECTOR> GetIsDetectorDevice(string clientId, int deviceType)
        {
            var command = string.Format("EXEC GETHOMEDETECTOR '{0}', {1}", clientId, deviceType);
            var device = db.Database.SqlQuery<GETHOMEDETECTOR>(command, "");

            return device;
        }

        #endregion

        #region Session Control
        public T CallWithSessionCheck<T>(Func<T> command, string userName, string password) where T : class
        {
            var session = command();
            if (GetUser() == null)
            {
                try
                {
                    var user = UserLogin(userName, password);
                    if (user == null)
                        throw new MemberAccessException("Invalid user");
                }
                catch { }

                try
                {
                    var admin = AdminLogin(userName, password);
                    if (admin == null)
                        throw new MemberAccessException("Invalid user");
                }
                catch { }

                return null;
            }
            return session;
        }

        public void SetSession(UserDto user)
        {
            HttpContext.Current.Session["user"] = user;
        }

        public void SetAdminSession(UserDto admin)
        {
            HttpContext.Current.Session["admin"] = admin;
        }

        public UserDto GetUser()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["user"] != null)
                return (UserDto)HttpContext.Current.Session["user"];
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["admin"] != null)
                return (UserDto)HttpContext.Current.Session["admin"];

            return null;
        }
        #endregion

        #region Log
        public void AddLog(MQTTResponse request)
        {
            LOG l = new LOG
            {
                CREATEDATE = DateTime.Now,
                QUERY = Encoding.UTF8.GetString(request.Message),
                QOSLEVEL = request.QoSLevel.ToString(),
                RETAIN = request.Retain.ToString(),
                TOPIC = request.Topic
            };
            db.Logs.Add(l);
            db.SaveChanges();
        }
        #endregion
    }
}