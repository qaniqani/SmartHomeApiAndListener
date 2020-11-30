using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace Model
{
    public class StaticValues
    {
        public enum StatusType
        {
            Active = 1,
            Deactive = 0
        }

        public enum UserType
        {
            Admin = 1,
            Homeowners = 2,
            ParentUser = 3
        }

        public enum IsDetector
        {
            Yes = 1,
            No = 0
        }

        public enum DeviceType
        {
            digitalWrite,
            analogWrite,
            digitalRead,
            analogRead,
            CarDoor,
            Curtain,
            Temperature,
            Fire,
            Water,
            Action,
            Gas,
            LightSensor
        }

        public enum SmartHomeStatusType
        {
            Yes = 1,
            No = 0
        }

        public static SelectList Status()
        {
            var li = new List<ListItem>();
            li.Add(new ListItem("Active", Convert.ToInt32(StatusType.Active).ToString()));
            li.Add(new ListItem("Deactive", Convert.ToInt32(StatusType.Deactive).ToString()));

            SelectList s = new SelectList(li, "Value", "Text");
            return s;
        }

        public static SelectList IsDetectorStatus()
        {
            var li = new List<ListItem>();
            li.Add(new ListItem(IsDetector.Yes.ToString(), Convert.ToInt32(IsDetector.Yes).ToString()));
            li.Add(new ListItem(IsDetector.No.ToString(), Convert.ToInt32(IsDetector.No).ToString()));

            SelectList s = new SelectList(li, "Value", "Text");
            return s;
        }

        public static SelectList SmartHomeStatus()
        {
            var li = new List<ListItem>();
            li.Add(new ListItem("Yes", Convert.ToInt32(SmartHomeStatusType.Yes).ToString()));
            li.Add(new ListItem("No", Convert.ToInt32(SmartHomeStatusType.No).ToString()));

            SelectList s = new SelectList(li, "Value", "Text");
            return s;
        }

        public static SelectList DeviceStatus()
        {
            var li = new List<ListItem>();
            li.Add(new ListItem(DeviceType.digitalWrite.ToString()));
            li.Add(new ListItem(DeviceType.analogWrite.ToString()));
            li.Add(new ListItem(DeviceType.digitalRead.ToString()));
            li.Add(new ListItem(DeviceType.analogRead.ToString()));
            li.Add(new ListItem(DeviceType.Curtain.ToString()));
            li.Add(new ListItem(DeviceType.CarDoor.ToString()));
            li.Add(new ListItem(DeviceType.Temperature.ToString()));
            li.Add(new ListItem(DeviceType.Fire.ToString()));
            li.Add(new ListItem(DeviceType.Water.ToString()));
            li.Add(new ListItem(DeviceType.Action.ToString()));
            li.Add(new ListItem(DeviceType.Gas.ToString()));
            li.Add(new ListItem(DeviceType.LightSensor.ToString()));

            SelectList s = new SelectList(li, "Value", "Text");
            return s;
        }

        public static SelectList UserStatus()
        {
            var li = new List<ListItem>();
            li.Add(new ListItem(UserType.Homeowners.ToString(), Convert.ToInt32(UserType.Homeowners).ToString()));
            li.Add(new ListItem(UserType.ParentUser.ToString(), Convert.ToInt32(UserType.ParentUser).ToString()));
            li.Add(new ListItem(UserType.Admin.ToString(), Convert.ToInt32(UserType.Admin).ToString()));

            SelectList s = new SelectList(li, "Value", "Text");
            return s;
        }

        public static SelectList ParentUserStatus()
        {
            var li = new List<ListItem>();
            li.Add(new ListItem("Homeowners", Convert.ToInt32(UserType.Homeowners).ToString()));
            li.Add(new ListItem("Parent User", Convert.ToInt32(UserType.ParentUser).ToString()));

            SelectList s = new SelectList(li, "Value", "Text");
            return s;
        }
    }
}