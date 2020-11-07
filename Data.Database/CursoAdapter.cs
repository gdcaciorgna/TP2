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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos cur inner join materias mat on cur.id_materia = mat.id_materia inner join comisiones com on com.id_comision = cur.id_comision", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCursos["id_curso"];
                    curso.Descripcion = (string)drCursos["desc_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];

                    curso.Materia =(string) drCursos["desc_materia"];
                    curso.Comision = (string)drCursos["desc_comision"];
                    


                    cursos.Add(curso);

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;

        }

        public List<int> GetAllAnios()
        {
            List<int> anios = new List<int>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdAnios = new SqlCommand("SELECT distinct anio_calendario from cursos", sqlConn);
                SqlDataReader drAnios = cmdAnios.ExecuteReader();

                while (drAnios.Read())
                {
                    int anio = new int();

                    anio = (int)drAnios["anio_calendario"];
                    
                    anios.Add(anio);

                }
                drAnios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de años", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return anios;


        }


        public List<Curso> GetAll(int anioCalendario)
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos cur inner join materias mat on cur.id_materia = mat.id_materia inner join comisiones com = com.id_comision = cur.id_comision where anio_calendario = @anio_calendario", sqlConn);
                cmdCursos.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = anioCalendario;
                
                SqlDataReader drCursos = cmdCursos.ExecuteReader();



                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCursos["id_curso"];
                    curso.Descripcion = (string)drCursos["desc_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.Materia = (string)drCursos["desc_materia"];
                    curso.Comision = (string)drCursos["desc_comision"];


                    cursos.Add(curso);

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;

        }


        public Business.Entities.Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos cur inner join materias mat on cur.id_materia = mat.id_materia inner join comisiones com = com.id_comision = cur.id_comision where id_curso = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.Descripcion = (string)drCursos["desc_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.Materia = (string)drCursos["desc_materia"];
                    curso.Comision = (string)drCursos["desc_comision"];



                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }

        public Curso GetOne(int id_comision, int id_materia, int anio_calendario)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos cur inner join materias mat on cur.id_materia = mat.id_materia inner join comisiones com = com.id_comision = cur.id_comision where id_comision = @id_comision and id_materia = @id_materia and anio_calendario = @anio_calendario", sqlConn);
                cmdCursos.Parameters.Add("@id_comision", SqlDbType.Int).Value = id_comision;
                cmdCursos.Parameters.Add("@id_materia", SqlDbType.Int).Value = id_materia;
                cmdCursos.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = anio_calendario;

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.Descripcion = (string)drCursos["desc_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.Materia = (string)drCursos["desc_materia"];
                    curso.Comision = (string)drCursos["desc_comision"];



                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;

        }



        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso = @id", sqlConn);
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

        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos set desc_curso = @desc_curso, id_materia = @id_materia, id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo WHERE id_curso = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@desc_curso", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into cursos (desc_curso, id_materia, id_comision, anio_calendario, cupo) values (@desc_curso, @id_materia, @id_comision, @anio_calendario, @cupo) select @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_curso", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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



        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }

    }
}
