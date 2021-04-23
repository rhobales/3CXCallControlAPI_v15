using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;

namespace OMSamples
{
    class MyListener
    {
        static int receivedNotifications = 0;
        public class MyEvent
        {
            public MyEvent(int operation, NotificationEventArgs e)
            {
                operation_ = operation;
                e_ = e;
            }
            public int operation_;
            public NotificationEventArgs e_;
        };

        String filter_ = null;
        public MyListener(String filter)
        {
            filter_ = filter;
        }

        void eventHandler(Object data)
        {
            MyEvent ev = data as MyEvent;
            if (ev != null)
            {
                NotificationEventArgs e = ev.e_;
                switch (ev.operation_)
                {
                    case 0: //insert
                        {
                            System.Console.WriteLine("Inserted: " + e.EntityName + "(" + e.RecID.ToString() + "):" + (e.ConfObject == null ? "no object" : e.ConfObject.ToString()));
                            ActiveConnection ac = e.ConfObject as ActiveConnection;
                            if (ac != null)
                            {
                                System.Console.WriteLine("AttachedData(" + ac.AttachedData.Count.ToString() + "):");
                                foreach (KeyValuePair<String, String> kvp in ac.AttachedData)
                                {
                                    System.Console.WriteLine(kvp.Key + "=" + kvp.Value);
                                }
                            }
                            if (e.EntityName == "REGISTRATION")
                            {
                                DN dn = e.ConfObject as DN;
                                foreach (RegistrarRecord rr in dn.GetRegistrarContactsEx())
                                {
                                    System.Console.WriteLine(rr.ToString() + "\nExpites=" + rr.Expires.ToString());
                                }
                            }
                        }
                        break;
                    case 1:
                        {
                            System.Console.WriteLine("Updated: " + e.EntityName + "(" + e.RecID.ToString() + "):" + (e.ConfObject == null ? "no object" : e.ConfObject.ToString()));
                            ActiveConnection ac = e.ConfObject as ActiveConnection;
                            if (ac != null)
                            {
                                System.Console.WriteLine("AttachedData(" + ac.AttachedData.Count.ToString() + "):");
                                foreach (KeyValuePair<String, String> kvp in ac.AttachedData)
                                {
                                    System.Console.WriteLine(kvp.Key + "=" + kvp.Value);
                                }
                            }
                            if (e.EntityName == "REGISTRATION")
                            {
                                DN dn = e.ConfObject as DN;
                                foreach (RegistrarRecord rr in dn.GetRegistrarContactsEx())
                                {
                                    System.Console.WriteLine(rr.ToString() + "\nExpites=" + rr.Expires.ToString());
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            System.Console.WriteLine("Deleted: " + e.EntityName + "(" + e.RecID.ToString() + "):" + (e.ConfObject == null ? "no object" : e.ConfObject.ToString()));

                            ActiveConnection ac = e.ConfObject as ActiveConnection;
                            if (ac != null)
                            {
                                System.Console.WriteLine("AttachedData(" + ac.AttachedData.Count.ToString() + "):");
                                foreach (KeyValuePair<String, String> kvp in ac.AttachedData)
                                {
                                    System.Console.WriteLine(kvp.Key + "=" + kvp.Value);
                                }
                            }
                            if (e.EntityName == "REGISTRATION")
                            {
                                DN dn = e.ConfObject as DN;
                                foreach (RegistrarRecord rr in dn.GetRegistrarContactsEx())
                                {
                                    System.Console.WriteLine(rr.ToString() + "\nExpites=" + rr.Expires.ToString());
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void ps_Inserted(object sender, NotificationEventArgs e)
        {
            if (filter_ != null && filter_ != e.EntityName)
                return;
            System.Console.WriteLine((receivedNotifications++).ToString());
            //ThreadPool.QueueUserWorkItem(this.eventHandler, new MyEvent(0, e));
            this.eventHandler(new MyEvent(0, e));
        }
        public void ps_Updated(object sender, NotificationEventArgs e)
        {
            if (filter_ != null && filter_ != e.EntityName)
                return;
            System.Console.WriteLine((receivedNotifications++).ToString());
            //ThreadPool.QueueUserWorkItem(this.eventHandler, new MyEvent(1, e));
            this.eventHandler(new MyEvent(1, e));
        }
        public void ps_Deleted(object sender, NotificationEventArgs e)
        {
            if (filter_ != null && filter_ != e.EntityName)
                return;
            System.Console.WriteLine((receivedNotifications++).ToString());
            //ThreadPool.QueueUserWorkItem(this.eventHandler, new MyEvent(2, e));
            this.eventHandler(new MyEvent(2, e));
        }
    }
}
