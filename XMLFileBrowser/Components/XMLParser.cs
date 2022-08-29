using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Components
{
    /// <summary>
    /// Парсес файлов формата XML
    /// </summary>
    public static class XMLParser
    {
        /// <summary>
        /// Парсит XML файл
        /// </summary>
        public static ObservableCollection<ChapterModel> ParceXML(string filePath)
        {
            XmlDocument xDoc = new XmlDocument();
            ObservableCollection<ChapterModel> chapterModels = new ObservableCollection<ChapterModel>();
            xDoc.Load(filePath);
            XmlElement xRoot = xDoc.DocumentElement;

            var chapters = xRoot?.SelectSingleNode("Chapters");
            if (chapters != null)
            {
                foreach (XmlNode chaptersNode in chapters)
                {
                    string chapterCaption = string.Empty;
                    ObservableCollection<PositionModel> positionModels = new ObservableCollection<PositionModel>();

                    chapterCaption = chaptersNode.SelectSingleNode("@Caption")?.Value;
                    Debug.WriteLine(chaptersNode.SelectSingleNode("@Caption")?.Value);

                    Debug.WriteLine("");

                    var positionNodes = chaptersNode?.SelectNodes("Position");

                    if (positionNodes != null)
                    {
                        foreach (XmlNode positionNode in positionNodes)
                        {
                            string positionCode = string.Empty;
                            string positionCaption = string.Empty;
                            string positionUnits = string.Empty;
                            string positionQuantityFx = string.Empty;
                            string positionQuantityResult = string.Empty;

                            ObservableCollection<ResourceModel> resourceModels = new ObservableCollection<ResourceModel>();

                            positionCode = positionNode.Attributes.GetNamedItem("Code")?.Value;
                            Debug.WriteLine("*** " + positionNode.Attributes.GetNamedItem("Code")?.Value);
                            positionCaption = positionNode.Attributes.GetNamedItem("Caption")?.Value;
                            Debug.WriteLine("*** " + positionNode.Attributes.GetNamedItem("Caption")?.Value);
                            positionUnits = positionNode.Attributes.GetNamedItem("Units")?.Value;
                            Debug.WriteLine("*** " + positionNode.Attributes.GetNamedItem("Units")?.Value);

                            XmlNode quantityNode = positionNode.SelectSingleNode("Quantity");

                            positionQuantityFx = quantityNode.Attributes.GetNamedItem("Fx")?.Value;
                            Debug.WriteLine("*** " + quantityNode.Attributes.GetNamedItem("Fx")?.Value);
                            positionQuantityResult = quantityNode.Attributes.GetNamedItem("Result")?.Value;
                            Debug.WriteLine("*** " + quantityNode.Attributes.GetNamedItem("Result")?.Value);

                            XmlNode resourcesNodes = positionNode.SelectSingleNode("Resources");

                            if (resourcesNodes != null)
                            {
                                foreach (XmlNode resourcesNode in resourcesNodes)
                                {
                                    string resourcesNodeCode = resourcesNode.Attributes.GetNamedItem("Code")?.Value;
                                    string resourcesNodeCaption = resourcesNode.Attributes.GetNamedItem("Caption")?.Value;
                                    string resourcesNodeQuantity = resourcesNode.Attributes.GetNamedItem("Quantity")?.Value;

                                    ResourceModel resourceModel = new ResourceModel(resourcesNodeCode, resourcesNodeCaption, resourcesNodeQuantity);
                                    resourceModels.Add(resourceModel);

                                    Debug.WriteLine("******* " + resourcesNodeCode);
                                    Debug.WriteLine("******* " + resourcesNodeCaption);
                                    Debug.WriteLine("******* " + resourcesNodeQuantity);
                                    Debug.WriteLine("---------------------------------------------");
                                }
                            }
                            PositionModel positionModel = new PositionModel(positionCode, positionCaption, positionUnits, positionQuantityFx, resourceModels);
                            positionModels.Add(positionModel);
                            Debug.WriteLine("");
                        }
                    }
                    ChapterModel chapterModel = new ChapterModel(chapterCaption, positionModels);
                    chapterModels.Add(chapterModel);
                }
            }
            return chapterModels;
        }
    }
}
