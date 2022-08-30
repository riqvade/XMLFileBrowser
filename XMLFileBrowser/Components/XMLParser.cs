using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml;
using XMLFileBrowser.Helpers;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Components
{
    /// <summary>
    /// Парсер
    /// </summary>
    public static class XMLParser
    {
        /// <summary>
        /// Возвращает распарсеное содержимое XML файла
        /// </summary>
        public static ObservableCollection<ChapterModel> ParceXMLFile(string filePath)
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
                    ObservableCollection<Position> positionModels = new ObservableCollection<Position>();

                    chapterCaption = chaptersNode.SelectSingleNode("@Caption")?.Value;
                    Debug.WriteLine(chaptersNode.SelectSingleNode("@Caption")?.Value);

                    Debug.WriteLine("");

                    var positionNodes = chaptersNode?.SelectNodes("Position");

                    if (positionNodes != null)
                    {
                        foreach (XmlNode positionNode in positionNodes)
                        {
                            string positionCode;
                            string positionCaption;
                            string positionUnits;
                            string positionQuantityFx;

                            ObservableCollection<Resource> resourceModels = new ObservableCollection<Resource>();

                            positionCode = positionNode.Attributes.GetNamedItem("Code")?.Value;
                            Debug.WriteLine("*** " + positionNode.Attributes.GetNamedItem("Code")?.Value);
                            positionCaption = positionNode.Attributes.GetNamedItem("Caption")?.Value;
                            Debug.WriteLine("*** " + positionNode.Attributes.GetNamedItem("Caption")?.Value);
                            positionUnits = positionNode.Attributes.GetNamedItem("Units")?.Value;
                            Debug.WriteLine("*** " + positionNode.Attributes.GetNamedItem("Units")?.Value);

                            XmlNode quantityNode = positionNode.SelectSingleNode("Quantity");

                            positionQuantityFx = quantityNode.Attributes.GetNamedItem("Fx")?.Value;
                            Debug.WriteLine("*** " + quantityNode.Attributes.GetNamedItem("Fx")?.Value);

                            positionQuantityFx = StringCalculator.ColculateNumExpression(positionQuantityFx);

                            Debug.WriteLine("*** " + positionQuantityFx);
                            Debug.WriteLine("*** Result From File" + quantityNode.Attributes.GetNamedItem("Result")?.Value);

                            XmlNode resourcesNodes = positionNode.SelectSingleNode("Resources");

                            if (resourcesNodes != null)
                            {
                                foreach (XmlNode resourcesNode in resourcesNodes)
                                {
                                    string resourcesNodeCode = resourcesNode.Attributes.GetNamedItem("Code")?.Value;
                                    string resourcesNodeCaption = resourcesNode.Attributes.GetNamedItem("Caption")?.Value;
                                    string resourcesNodeQuantity = resourcesNode.Attributes.GetNamedItem("Quantity")?.Value;

                                    Resource resourceModel = new Resource(resourcesNodeCode, resourcesNodeCaption, resourcesNodeQuantity);
                                    resourceModels.Add(resourceModel);

                                    Debug.WriteLine("******* " + resourcesNodeCode);
                                    Debug.WriteLine("******* " + resourcesNodeCaption);
                                    Debug.WriteLine("******* " + resourcesNodeQuantity);
                                    Debug.WriteLine("---------------------------------------------");
                                }
                            }

                            Position positionModel = new Position(positionCode, positionCaption, positionUnits, positionQuantityFx, resourceModels, (positionModels.Count + 1).ToString());
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
