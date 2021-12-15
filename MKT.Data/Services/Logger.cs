using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Web;
using System.Data;

namespace MKT.Data.Services
{

        public enum State { Info, Error, BizChange, UserChange, Critical, }

        public class Logger
        {

            public string severity { get; set; }
            public string Controller { get; set; }
            public string Message { get; set; }
            public string Date { get; set; }

            public static void WriteLog(State St, object AccionController, string IdMsj)
            {

                string DatePath = Logger.GetNameFile();
                string PathXML = HttpContext.Current.Server.MapPath("~/LogXML/" + DatePath);
                String ArcXML = PathXML + "/" + DatePath + ".xml";

                try
                {
                    if (!Directory.Exists(PathXML))
                    {
                        Directory.CreateDirectory(PathXML);

                        //estructura basica para el xml, no guarda solo prologo

                        XmlDocument doc = new XmlDocument();
                        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        XmlElement root = doc.DocumentElement;
                        doc.InsertBefore(xmlDeclaration, root);
                        XmlElement element1 = doc.CreateElement(string.Empty, "logger", string.Empty);
                        doc.AppendChild(element1);

                        doc.Save(ArcXML);


                    }
                    else
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(ArcXML);
                        XmlNode nodeLog = doc.CreateElement("Log");

                        XmlNode nodeSeverity = doc.CreateElement("Severity");
                        nodeSeverity.InnerText = St.ToString();

                        XmlNode nodeController = doc.CreateElement("Controller");
                        nodeController.InnerText = AccionController.ToString();

                        XmlNode nodeIdMsj = doc.CreateElement("IdMsj");
                        nodeIdMsj.InnerText = IdMsj;

                        XmlNode nodeFecha = doc.CreateElement("Date");
                        nodeFecha.InnerText = DateTime.Now.ToString();

                        nodeLog.AppendChild(nodeSeverity);
                        nodeLog.AppendChild(nodeController);
                        nodeLog.AppendChild(nodeFecha);
                        nodeLog.AppendChild(nodeIdMsj);

                        doc.SelectSingleNode("logger").AppendChild(nodeLog);
                        doc.Save(ArcXML);

                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            /*--------Nombre de Directorio----*/

            private static string GetNameFile()

            {
                string nombre = "";

                nombre = "log_" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                return nombre;
            }

            /*--------XML++++++++++READ----*/

            public static List<Logger> ReadLog(string DatePath)

            {

                //Logger logger = new Logger();
                List<Logger> loggers = new List<Logger>();

                //formar ruta de busqueda con fecha

                string PathXML = HttpContext.Current.Server.MapPath("~/LogXML/" + "log_" + DatePath);
                String ArcXML = PathXML + "/" + "log_" + DatePath + ".xml";


                XmlDocument doc = new XmlDocument();
                doc.Load(ArcXML);


                foreach (XmlNode node in doc.SelectNodes("/logger/Log"))
                {

                    loggers.Add(new Logger
                    {
                        severity = node["Severity"].InnerText,
                        Controller = node["Controller"].InnerText,
                        Message = node["IdMsj"].InnerText,
                        Date = node["Date"].InnerText
                    });
                }

                return (loggers);

            }


        }
    }

