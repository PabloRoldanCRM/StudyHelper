using System;
using System.Collections.Generic;
using System.Text;

namespace StudyHelperApp.Model
{
     public class Question
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string Respuestas { get; set; }
        public List<string> RespuestasList { get; set; }
        public string Respuesta { get; set; }
    }
}
