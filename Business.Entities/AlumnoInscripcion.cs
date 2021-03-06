﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private string _Condicion;
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        private int _IDAlumno;
        public int IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        private int _IDCurso;
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }




        private int _Nota;
        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        
        private string _descCurso;

        public string DescCurso
        {
            get { return _descCurso; }
            set { _descCurso = value; }
        }

        private string _alumno;

        public string Alumno
        {
            get { return _alumno; }
            set { _alumno = value; }
        }


        public string Materia { get; set; }

        public string Comision { get; set; }

        public int AnioCalendario { get; set; }


    }
}
