using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAllDocentesPorCurso(int cur)
        {
            List<DocenteCurso> docentesCurso = new List<DocenteCurso>();
            try
            {

                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * from docentes_cursos where id_curso = @id_curso", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id_curso", SqlDbType.Int).Value = cur;


                SqlDataReader drDocentesCursos = cmdDocenteCurso.ExecuteReader();
                while (drDocentesCursos.Read())
                {
                    DocenteCurso docCur = new DocenteCurso();

                    docCur.ID = (int)drDocentesCursos["id_dictado"];
                    docCur.IDCurso = (int)drDocentesCursos["id_curso"];
                    docCur.IDDocente = (int)drDocentesCursos["id_docente"];
                    docCur.Cargo = (DocenteCurso.TiposCargo)drDocentesCursos["cargo"];

                    docentesCurso.Add(docCur);

                }

                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de docentes por curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docentesCurso;

        }


        public List<DocenteCurso> GetAll() 
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos", sqlConn);
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();

                while (drDocentesCursos.Read())
                {
                    DocenteCurso docCurso = new DocenteCurso();
                    docCurso.ID = (int)drDocentesCursos["id_dictado"];
                    docCurso.IDCurso = (int)drDocentesCursos["id_curso"];
                    docCurso.IDDocente = (int)drDocentesCursos["id_docente"];
                    docCurso.Cargo = (DocenteCurso.TiposCargo)drDocentesCursos["cargo"];

                    docentesCursos.Add(docCurso);

                }
                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de docentes cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docentesCursos;
        }


    }
}
