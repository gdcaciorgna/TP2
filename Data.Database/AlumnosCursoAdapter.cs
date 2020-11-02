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
    public class AlumnosCursoAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAllAlumnosPorCurso(int cur)
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();
            try
            {

                this.OpenConnection();
                SqlCommand cmdAlumnoInsc = new SqlCommand("SELECT * from alumnos_inscripciones where id_curso = @id_curso", sqlConn);
                cmdAlumnoInsc.Parameters.Add("@id_curso", SqlDbType.Int).Value = cur;


                SqlDataReader drAlumnoInsc = cmdAlumnoInsc.ExecuteReader();
                while (drAlumnoInsc.Read())
                {
                    AlumnoInscripcion aluInsc = new AlumnoInscripcion();

                    aluInsc.ID = (int)drAlumnoInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnoInsc["id_alumno"];
                    aluInsc.Condicion = (string)drAlumnoInsc["condicion"];
                    aluInsc.IDCurso = (int)drAlumnoInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnoInsc["nota"];

                    alumnosInscripciones.Add(aluInsc);

                }

                drAlumnoInsc.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de inscripciones de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnosInscripciones;

        }


        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInsc = new SqlCommand("select * from alumnos_inscripciones", sqlConn);
                SqlDataReader drAlumnosInsc = cmdAlumnosInsc.ExecuteReader();

                while (drAlumnosInsc.Read())
                {
                    AlumnoInscripcion aluInsc = new AlumnoInscripcion();
                    aluInsc.ID = (int)drAlumnosInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnosInsc["id_alumno"];
                    aluInsc.IDCurso = (int)drAlumnosInsc["id_curso"];
                    aluInsc.Condicion = (string)drAlumnosInsc["condicion"];
                    aluInsc.Nota = (int)drAlumnosInsc["nota"];

                    alumnosInscripciones.Add(aluInsc);

                }
                drAlumnosInsc.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de inscripciones de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnosInscripciones;
        }


        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion aluInsc = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInsc = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdAlumnosInsc.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnosInsc = cmdAlumnosInsc.ExecuteReader();

                if (drAlumnosInsc.Read())
                {
                    aluInsc.ID = (int)drAlumnosInsc["id_inscripcion"];
                    aluInsc.IDAlumno  = (int)drAlumnosInsc["id_alumno"];
                    aluInsc.IDCurso = (int)drAlumnosInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnosInsc["nota"];
                    aluInsc.Condicion = (string)drAlumnosInsc["condicion"];
                    
                }
                drAlumnosInsc.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return aluInsc;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }



        public void Update(AlumnoInscripcion aluInsc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones set id_alumno = @id_alumno, id_curso = @id_curso, nota = @nota, condicion = @condicion WHERE id_inscripcion = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = aluInsc.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = aluInsc.IDAlumno;
                cmdSave.Parameters.Add("id_curso", SqlDbType.Int).Value = aluInsc.IDCurso;
                cmdSave.Parameters.Add("nota", SqlDbType.Int).Value = aluInsc.Nota;
                cmdSave.Parameters.Add("condicion", SqlDbType.VarChar, 50).Value = aluInsc.Condicion;

                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos de la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }




        public void Insert(AlumnoInscripcion aluInsc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into alumnos_inscripciones (id_alumno, id_curso, condicion, nota) values (@id_alumno, @id_curso, @condicion, @nota) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = aluInsc.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = aluInsc.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = aluInsc.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.VarChar,50).Value = aluInsc.Nota;

                aluInsc.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(AlumnoInscripcion aluInsc)
        {
            if (aluInsc.State == BusinessEntity.States.New)
            {
                this.Insert(aluInsc);
            }
            else if (aluInsc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(aluInsc.ID);
            }
            else if (aluInsc.State == BusinessEntity.States.Modified)
            {
                this.Update(aluInsc);
            }
            aluInsc.State = BusinessEntity.States.Unmodified;
        }

    }
}
