using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;

namespace Shijra.Helpers
{
    class VisioDrawer
    {
        // the Visio applicaiton we will work with
        public Visio.Application VisApp;
        // the collection of shape masters
        // these are the collections you can choose from when drawing in the Visio application
        public Visio.Documents MastersDocuments;
        // the document that holds the masters we will be working with
        public Visio.Document MasterDoc;
        // the Masters collection we will get shapes from
        public Visio.Masters Masters;
        //  the document we wil be working with
        public Visio.Document ActiveDoc;
        // the page we will put shapes on
        public Visio.Page ActivePage;


        public VisioDrawer()
        {
            //create the application
            VisApp = new Visio.Application();
            // add a new document - this becomes the active document
            // if we do not do this we get throw an exception
            VisApp.Documents.Add(@"");
            MastersDocuments = VisApp.Documents;
            
            // open the page holding the masters collection so we can use it
            // Basic_U.vss is the name of the collection, you could use a different collection
            MasterDoc = MastersDocuments.OpenEx(@"Basic_U.vss", (short)Visio.VisOpenSaveArgs.visOpenDocked);
            
            // now get a masters collection to use 
            Masters = MasterDoc.Masters;
            // now get the active document
            ActiveDoc = VisApp.ActiveDocument;
            // Create a page to put our shapes on
            ActivePage = ActiveDoc.Pages.Add();

        }


        private Visio.Master GetMaster(string mastername)
        {
            return Masters.get_ItemU(mastername);
        }

        public void DropShape(string name, double x, double y)
        {
            //get the shape to drop from the masters collection
            //this time it is a simple rectangle
            Visio.Master shapetodrop = GetMaster(@"Rounded rectangle");
            
            // drop a shape on the page
            Visio.Shape DropShape = ActivePage.Drop(shapetodrop, x, y);
            // set the name on the shape
            DropShape.Name = name;
            
            //now lets set the text on the shape
            DropShape.Text = name;
        }

        public void ConnectShapes(Visio.Shape fromShape, Visio.Shape toShape)
        {
            // get the connector 
            // this is one kind, there are others
            // this particular style does not have arrows
            Visio.Master ConnectionMaster = GetMaster(@"Dynamic connector");

            // we need to put the connector on the page before we can use it
            Visio.Shape Connector = ActivePage.Drop(ConnectionMaster, 9, 9);
            
            //now get one end of the connector
            Visio.Cell beginXCell = Connector.get_CellsSRC((short)Visio.VisSectionIndices.visSectionObject,
                         (short)Visio.VisRowIndices.visRowXForm1D,
                            (short)Visio.VisCellIndices.vis1DBeginX);
            // now get the other end
            Visio.Cell endXCell = Connector.get_CellsSRC((short)Visio.VisSectionIndices.visSectionObject,
                         (short)Visio.VisRowIndices.visRowXForm1D,
                            (short)Visio.VisCellIndices.vis1DEndX);


            //now attach one end of the connector to one of the shapes we passed in to the method
            beginXCell.GlueTo(fromShape.get_CellsSRC((short)Visio.VisSectionIndices.visSectionObject,
                                (short)Visio.VisRowIndices.visRowXFormOut,
                                  (short)Visio.VisCellIndices.visXFormPinX));
            // and do the same for the other end
            endXCell.GlueTo(toShape.get_CellsSRC((short)Visio.VisSectionIndices.visSectionObject,
                            (short)Visio.VisRowIndices.visRowXFormOut,
                            (short)Visio.VisCellIndices.visXFormPinX));
        }
        public Visio.Shape GetShapeByName(string name)
        {
            //this method demonstrates how to find a shape on a page by name
            IEnumerable<Visio.Shape> existingswitch = from Visio.Shape ashape in ActivePage.Shapes where name == ashape.Name select ashape;
            return existingswitch.FirstOrDefault();
        }
    }
}
