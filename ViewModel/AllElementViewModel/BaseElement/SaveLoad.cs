using Newtonsoft.Json;
using SimulatorLogicDevices.Model;
using SimulatorLogicDevices.Model.BaseElements;
using SimulatorLogicDevices.Model.HelperDevices;
using SimulatorLogicDevices.View.MainWindow.Pages;
using SimulatorLogicDevices.ViewModel.DialogService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement
{
    internal class SaveLoad
    {
        SaveObj obj = new SaveObj();
        DefaultDialogService defaultDialogService = new DefaultDialogService();
        public void Save(string path)
        {
            obj.elements = AddElementsInCanvas.elements;
            obj.linkElements = AddElementsInCanvas.linkElements;

            string json = JsonConvert.SerializeObject(obj);

            try
            {
                using (StreamWriter writer = new StreamWriter(path + ".json"))
                {
                    writer.WriteLine(json);
                }
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }

        public void Load(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                obj = JsonConvert.DeserializeObject<SaveObj>(json);
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
            for (int i = 0; i < obj.elements.Count; i++)
            {
                if (obj.elements[i].elementType == ElementType.AND)
                {
                    AND _element = new AND();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].inputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.OR)
                {
                    OR _element = new OR();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].inputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.XOR)
                {
                    XOR _element = new XOR();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].inputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.ANDNOT)
                {
                    AND_NOT _element = new AND_NOT();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].inputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.ORNOT)
                {
                    OR_NOT _element = new OR_NOT();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].inputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.BUTTON)
                {
                    ButtonE _element = new ButtonE();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].outputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.GENERATOR)
                {
                    Generator _element = new Generator();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].outputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.NOT)
                {
                    NOT _element = new NOT();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].inputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.LED)
                {
                    LED _element = new LED();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].inputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.RSTRIGGER)
                {
                    RS_Trigger _element = new RS_Trigger();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].inputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.DELIMITER)
                {
                    Delimiter _element = new Delimiter();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].outputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.COUNTER)
                {
                    Counter _element = new Counter();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].outputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
                else if (obj.elements[i].elementType == ElementType.DTRIGGER)
                {
                    D_Trigger _element = new D_Trigger();
                    _element.setId(obj.elements[i].id);
                    _element.Resize(obj.elements[i].inputs);
                    AddElementsInCanvas.AddElements(_element, obj.elements[i].positionX, obj.elements[i].positionY);
                }
            }

            for (int i = 0; i < obj.linkElements.Count; i++)
            {
                Line _curLine = new Line();

                _curLine.StrokeThickness = 3;
                _curLine.Stroke = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");

                _curLine.X1 = 0;
                _curLine.Y1 = 0;
                _curLine.X2 = 0;
                _curLine.Y2 = 0;

                IElements first = null, second = null;

                for (int j = 0; j < AddElementsInCanvas.elements.Count; j++)
                {
                    if (AddElementsInCanvas.elements[j].id == obj.linkElements[i].firstElement)
                    {
                        first = AddElementsInCanvas.elements[j].elements;
                    }
                    if (AddElementsInCanvas.elements[j].id == obj.linkElements[i].secondElement)
                    {
                        second = AddElementsInCanvas.elements[j].elements;
                    }
                }

                if (first != null && second != null)
                {
                    first.ConnectOutput(obj.linkElements[i].firstPort, first, _curLine);
                    second.ConnectInput(obj.linkElements[i].secondPort, second, _curLine);
                    first.TriggerSetInputValue();
                }

                MainPage.getCanvas().Children.Add(_curLine);
            }
        }
    }

    class SaveObj
    {
        public List<ElementsSaveValue> elements = new List<ElementsSaveValue>();
        public List<LinkElements> linkElements = new List<LinkElements>();
    }
}
