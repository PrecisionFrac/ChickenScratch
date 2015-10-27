using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Ink;
using System.Windows.Input;
using WebApplication.Results;

namespace WebApplication.Controllers.Handwriting
{
    public class RecognitionController : ApiController
    {
        // GET: api/Recognition
        [HttpGet]
        public String Get()
        {
            return "Value";
        }

        // GET: api/Recognition/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Recognition
        [HttpPost]
        [ActionName("Recognize")]
        public String Recognize([FromBody] Results.Stroke stroke)
        {
            var strokePointsData = JsonConvert.DeserializeObject<dynamic>(stroke.Json);

            var strokeCollection = GetStrokeCollectionFromPoints(strokePointsData);

            var inkAnalyzer = new InkAnalyzer();

            inkAnalyzer.AddStrokes(strokeCollection);

            var analysisStatus = inkAnalyzer.Analyze();

            if (analysisStatus.Successful)
            {
                var recognizedString = inkAnalyzer.GetRecognizedString();
                return recognizedString;
            }
            else
                return "Data not recognized";
        }

        // PUT: api/Recognition/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Recognition/5
        public void Delete(int id)
        {
        }

        private StrokeCollection GetStrokeCollectionFromPoints(dynamic strokePoints)
        {
            var strokeCollection = new StrokeCollection();

            foreach (var stroke in strokePoints.Strokes)
            {
                var points = new StylusPointCollection();

                foreach (var point in stroke.Points)
                {
                    var x = (float)point.X;
                    var y = (float)point.Y;

                    points.Add(new StylusPoint(x, y));
                }

                strokeCollection.Add(new System.Windows.Ink.Stroke(points));
            }

            return strokeCollection;
        }
    }
}
