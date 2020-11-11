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
    public class AlumnosInscripcionesdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAllAlumnosPorCurso(int cur)
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();
            try
            {

                this.OpenConnection();
                SqlCommand cmdAlumnoInsc = new SqlCommand("SELECT * from alumnos_inscripciones ai inner join cursos cu on ai.id_curso = cu.id_curso inner join personas pe on ai.id_alumno = pe.id_persona inner join materias mat on mat.id_materia=cu.id_materia inner join comisiones com on com.id_comision = cu.id_comision  where ai.id_curso = @id_curso", sqlConn);
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
                    aluInsc.DescCurso = drAlumnoInsc["desc_materia"] + " " + drAlumnoInsc["desc_comision"] + " " + drAlumnoInsc["anio_calendario"];



                    string nombre = (string)drAlumnoInsc["nombre"];
                    string apellido = (string)drAlumnoInsc["apellido"];
                    string legajo = ((int)drAlumnoInsc["legajo"]).ToString();

                    string descAlumno = apellido + " " + nombre + " - " + legajo;
                    aluInsc.Alumno = descAlumno;

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
                SqlCommand cmdAlumnosInsc = new SqlCommand("SELECT * from alumnos_inscripciones ai inner join cursos cu on ai.id_curso = cu.id_curso inner join personas pe on ai.id_alumno = pe.id_persona inner join materias mat on mat.id_materia=cu.id_materia inner join comisiones com on com.id_comision = cu.id_comision", sqlConn);
                SqlDataReader drAlumnosInsc = cmdAlumnosInsc.ExecuteReader();

                while (drAlumnosInsc.Read())
                {
                    AlumnoInscripcion aluInsc = new AlumnoInscripcion();
                    aluInsc.ID = (int)drAlumnosInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnosInsc["id_alumno"];
                    aluInsc.IDCurso = (int)drAlumnosInsc["id_curso"];
                    aluInsc.Condicion = (string)drAlumnosInsc["condicion"];
                    aluInsc.Nota = (int)drAlumnosInsc["nota"];

                    string nombre = (string)drAlumnosInsc["nombre"];
                    string apellido = (string)drAlumnosInsc["apellido"];
                    string legajo = ((int)drAlumnosInsc["legajo"]).ToString();
                    
                    string descAlumno = apellido + " " + nombre + " - " + legajo;
                    aluInsc.Alumno = descAlumno;
                    aluInsc.DescCurso = drAlumnosInsc["desc_materia"] + " " + drAlumnosInsc["desc_comision"] + " " + drAlumnosInsc["anio_calendario"];

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
                SqlCommand cmdAlumnosInsc = new SqlCommand("SELECT * from alumnos_inscripciones ai inner join cursos cu on ai.id_curso = cu.id_curso inner join personas pe on ai.id_alumno = pe.id_persona inner join materias mat on mat.id_materia=cu.id_materia inner join comisiones com on com.id_comision = cu.id_comision where id_inscripcion = @id", sqlConn);
                cmdAlumnosInsc.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnosInsc = cmdAlumnosInsc.ExecuteReader();

                if (drAlumnosInsc.Read())
                {
                    aluInsc.ID = (int)drAlumnosInsc["id_inscripcion"];
                    aluInsc.IDAlumno  = (int)drAlumnosInsc["id_alumno"];
                    aluInsc.IDCurso = (int)drAlumnosInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnosInsc["nota"];
                    aluInsc.Condicion = (string)drAlumnosInsc["condicion"];

                    string nombre = (string)drAlumnosInsc["nombre"];
                    string apellido = (string)drAlumnosInsc["apellido"];
                    string legajo = ((int)drAlumnosInsc["legajo"]).ToString();

                    string descAlumno = apellido + " " + nombre + " - " + legajo;

                    aluInsc.Alumno = descAlumno;
                    aluInsc.DescCurso = drAlumnosInsc["desc_materia"] + " " + drAlumnosInsc["desc_comision"] + " " + drAlumnosInsc["anio_calendario"];


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


        public AlumnoInscripcion GetOne(int id_alumno, int id_curso)
        {
            AlumnoInscripcion aluInsc = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInsc = new SqlCommand("SELECT * from alumnos_inscripciones ai inner join cursos cu on ai.id_curso = cu.id_curso inner join personas pe on ai.id_alumno = pe.id_persona inner join materias mat on mat.id_materia=cu.id_materia inner join comisiones com on com.id_comision = cu.id_comision where ai.id_alumno = @id_alumno and ai.id_curso = @id_curso", sqlConn);
                cmdAlumnosInsc.Parameters.Add("@id_alumno", SqlDbType.Int).Value = id_alumno;
                cmdAlumnosInsc.Parameters.Add("@id_curso", SqlDbType.Int).Value = id_curso;
                SqlDataReader drAlumnosInsc = cmdAlumnosInsc.ExecuteReader();

                if (drAlumnosInsc.Read())
                {
                    aluInsc.ID = (int)drAlumnosInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnosInsc["id_alumno"];
                    aluInsc.IDCurso = (int)drAlumnosInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnosInsc["nota"];
                    aluInsc.Condicion = (string)drAlumnosInsc["condicion"];

                    string nombre = (string)drAlumnosInsc["nombre"];
                    string apellido = (string)drAlumnosInsc["apellido"];
                    string legajo = ((int)drAlumnosInsc["legajo"]).ToString();

                    string descAlumno = apellido + " " + nombre + " - " + legajo;

                    aluInsc.Alumno = descAlumno;
                    aluInsc.DescCurso = drAlumnosInsc["desc_materia"] + " " + drAlumnosInsc["desc_comision"] + " " + drAlumnosInsc["anio_calendario"];


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



        public int ContarAlumnosInscriptosACurso(Curso cur)
        {

            int cant = 0;

            try
            {
                this.OpenConnection();
                SqlCommand cmdAluInsc = new SqlCommand("select COUNT(id_curso) 'cantidad_alumnos' from alumnos_inscripciones where id_curso = @id_curso", sqlConn);
                cmdAluInsc.Parameters.Add("@id_curso", SqlDbType.Int).Value = cur.ID;
                SqlDataReader drAluInsc = cmdAluInsc.ExecuteReader();

                if (drAluInsc.Read())
                {
                    cant = (int)drAluInsc[0];
                }


                drAluInsc.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                this.CloseConnection();
            }
            return cant;

        }







        public List<AlumnoInscripcion> GetAllInscripcionesPorAlumno(int id_alumno)
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();
            try
            {

                this.OpenConnection();
                SqlCommand cmdAlumnoInsc = new SqlCommand("SELECT * from alumnos_inscripciones ai inner join cursos cu on ai.id_curso = cu.id_curso inner join personas pe on ai.id_alumno = pe.id_persona inner join materias mat on mat.id_materia=cu.id_materia inner join comisiones com on com.id_comision = cu.id_comision  where id_alumno = @id_alumno", sqlConn);
                cmdAlumnoInsc.Parameters.Add("@id_alumno", SqlDbType.Int).Value = id_alumno;


                SqlDataReader drAlumnoInsc = cmdAlumnoInsc.ExecuteReader();
                while (drAlumnoInsc.Read())
                {
                    AlumnoInscripcion aluInsc = new AlumnoInscripcion();

                    aluInsc.ID = (int)drAlumnoInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnoInsc["id_alumno"];
                    aluInsc.Condicion = (string)drAlumnoInsc["condicion"];
                    aluInsc.IDCurso = (int)drAlumnoInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnoInsc["nota"];
                    aluInsc.DescCurso = drAlumnoInsc["desc_materia"] + " " + drAlumnoInsc["desc_comision"] + " " + drAlumnoInsc["anio_calendario"];


                    string nombre = (string)drAlumnoInsc["nombre"];
                    string apellido = (string)drAlumnoInsc["apellido"];
                    string legajo = ((int)drAlumnoInsc["legajo"]).ToString();

                    string descAlumno = apellido + " " + nombre + " - " + legajo;
                    aluInsc.Alumno = descAlumno;

                    alumnosInscripciones.Add(aluInsc);



                }

                drAlumnoInsc.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de las inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnosInscripciones;

        }

        public List<AlumnoInscripcion> GetAllInscripcionesPorAlumno(int id_alumno, int anio_cal)
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();
            try
            {

                this.OpenConnection();
                SqlCommand cmdAlumnoInsc = new SqlCommand("SELECT * from alumnos_inscripciones ai inner join cursos cu on ai.id_curso = cu.id_curso inner join personas pe on ai.id_alumno = pe.id_persona inner join materias mat on mat.id_materia=cu.id_materia inner join comisiones com on com.id_comision = cu.id_comision where id_alumno = @id_alumno and anio_calendario = @anio_calendario", sqlConn);
                cmdAlumnoInsc.Parameters.Add("@id_alumno", SqlDbType.Int).Value = id_alumno;
                cmdAlumnoInsc.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = anio_cal;


                SqlDataReader drAlumnoInsc = cmdAlumnoInsc.ExecuteReader();
                while (drAlumnoInsc.Read())
                {
                    AlumnoInscripcion aluInsc = new AlumnoInscripcion();

                    aluInsc.ID = (int)drAlumnoInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnoInsc["id_alumno"];
                    aluInsc.Condicion = (string)drAlumnoInsc["condicion"];
                    aluInsc.IDCurso = (int)drAlumnoInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnoInsc["nota"];
                    aluInsc.DescCurso = drAlumnoInsc["desc_materia"] + " " + drAlumnoInsc["desc_comision"] + " " + drAlumnoInsc["anio_calendario"];


                    string nombre = (string)drAlumnoInsc["nombre"];
                    string apellido = (string)drAlumnoInsc["apellido"];
                    string legajo = ((int)drAlumnoInsc["legajo"]).ToString();

                    string descAlumno = apellido + " " + nombre + " - " + legajo;
                    aluInsc.Alumno = descAlumno;

                    alumnosInscripciones.Add(aluInsc);



                }

                drAlumnoInsc.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de las inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnosInscripciones;

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
