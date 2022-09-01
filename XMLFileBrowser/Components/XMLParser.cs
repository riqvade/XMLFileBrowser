using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
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
            string filename = Path.GetFileName(filePath);
            ObservableCollection<ChapterModel> chapterModels = new ObservableCollection<ChapterModel>();

            try
            {
                xDoc.Load(filePath);
            }
            catch (IOException e)
            {
                MessageBox.Show($"Не удалось загрузить файл: {filename}, возможно файл поврежден.");
                Debug.WriteLine(e.Message);

                return null;
            }

            XmlElement xRoot = xDoc.DocumentElement;

            var chapters = xRoot?.SelectSingleNode("Chapters");
            if (chapters != null)
            {
                foreach (XmlNode chaptersNode in chapters)
                {
                    string chapterCaption = string.Empty;
                    ObservableCollection<Position> positionModels = new ObservableCollection<Position>();

                    chapterCaption = chaptersNode.SelectSingleNode("@Caption")?.Value;
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
                            positionCaption = positionNode.Attributes.GetNamedItem("Caption")?.Value;
                            positionUnits = positionNode.Attributes.GetNamedItem("Units")?.Value;

                            XmlNode quantityNode = positionNode.SelectSingleNode("Quantity");

                            positionQuantityFx = quantityNode.Attributes.GetNamedItem("Fx")?.Value;
                            positionQuantityFx = StringCalculator.ColculateNumExpression(positionQuantityFx);

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
                                }
                            }

                            Position positionModel = new Position(positionCode, positionCaption, positionUnits, positionQuantityFx, resourceModels, (positionModels.Count + 1).ToString());
                            positionModels.Add(positionModel);
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
