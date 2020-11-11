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
                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos dc join personas p on dc.id_docente = p.id_persona  where id_curso = @id_curso", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id_curso", SqlDbType.Int).Value = cur;


                SqlDataReader drDocentesCursos = cmdDocenteCurso.ExecuteReader();
                while (drDocentesCursos.Read())
                {
                    DocenteCurso docCur = new DocenteCurso();

                    docCur.ID = (int)drDocentesCursos["id_dictado"];
                    docCur.IDCurso = (int)drDocentesCursos["id_curso"];
                    docCur.IDDocente = (int)drDocentesCursos["id_docente"];
                    docCur.Cargo = (DocenteCurso.TiposCargo)drDocentesCursos["cargo"];
                    
                    string apellido = (string)drDocentesCursos["apellido"];
                    string nombre = (string)drDocentesCursos["nombre"];

                    docCur.Docente = apellido + " " + nombre;


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
                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos dc join personas p on dc.id_docente = p.id_persona", sqlConn);
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();

                while (drDocentesCursos.Read())
                {
                    DocenteCurso docCurso = new DocenteCurso();
                    docCurso.ID = (int)drDocentesCursos["id_dictado"];
                    docCurso.IDCurso = (int)drDocentesCursos["id_curso"];
                    docCurso.IDDocente = (int)drDocentesCursos["id_docente"];
                    docCurso.Cargo = (DocenteCurso.TiposCargo)drDocentesCursos["cargo"];

                    string apellido = (string)drDocentesCursos["apellido"];
                    string nombre = (string)drDocentesCursos["nombre"];

                    docCurso.Docente = apellido + " " + nombre;

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


        public List<Curso> GetAll(int id_docente)
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos dc inner join cursos cu on dc.id_curso = cu.id_curso inner join materia mat on mat.id_materia = cu.id_materia inner join comisiones com on com.id_comision = cu.id_comision where id_docente = @id_docente ", sqlConn);
                cmdDocentesCursos.Parameters.Add("@id_docente", SqlDbType.Int).Value = id_docente;
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();

                while (drDocentesCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drDocentesCursos["id_curso"];
                    curso.IDMateria = (int)drDocentesCursos["id_materia"];
                    curso.IDComision = (int)drDocentesCursos["id_comision"];
                    curso.AnioCalendario = (int)drDocentesCursos["anio_calendario"];
                    curso.Cupo = (int)drDocentesCursos["cupo"];

                    curso.Descripcion = drDocentesCursos["desc_materia"] + " " + drDocentesCursos["desc_comision"] + " " +  curso.AnioCalendario;

                    cursos.Add(curso);

                }
                drDocentesCursos.Close();
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


        public DocenteCurso GetOne(int ID)
        {
           DocenteCurso docCur = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmddocCur = new SqlCommand("select * from docentes_cursos dc join personas p on dc.id_docente = p.id_persona where id_dictado = @id", sqlConn);
                cmddocCur.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drdocCur = cmddocCur.ExecuteReader();

                if (drdocCur.Read())
                {
                    docCur.ID = (int)drdocCur["id_dictado"];
                    docCur.IDCurso = (int)drdocCur["id_curso"];
                    docCur.IDDocente = (int)drdocCur["id_docente"];
                    docCur.Cargo = (DocenteCurso.TiposCargo)drdocCur["cargo"];

                    string apellido = (string)drdocCur["apellido"];
                    string nombre = (string)drdocCur["nombre"];

                    docCur.Docente = apellido + " " + nombre;



                }
                drdocCur.Close();
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
            return docCur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado = @id", sqlConn);
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

        public void Insert(DocenteCurso docCur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into docentes_cursos (id_curso, id_docente, cargo) values (@id_curso, @id_docente, @cargo) select @@identity", sqlConn);

                
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docCur.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docCur.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docCur.Cargo;

                docCur.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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

        public void Update(DocenteCurso docCur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos set id_docente = @id_docente, id_curso = @id_curso, cargo = @cargo WHERE id_dictado = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docCur.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docCur.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docCur.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docCur.Cargo;
                

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
        public void Save(DocenteCurso docCur)
        {
            if (docCur.State == BusinessEntity.States.New)
            {
                this.Insert(docCur);
            }
            else if (docCur.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docCur.ID);
            }
            else if (docCur.State == BusinessEntity.States.Modified)
            {
                this.Update(docCur);
            }
            docCur.State = BusinessEntity.States.Unmodified;
        }


        public List<DocenteCurso> GetAllDocentesCursos()
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos dc join personas p on dc.id_docente = p.id_persona", sqlConn);
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();

                while (drDocentesCursos.Read())
                {
                    DocenteCurso docCurso = new DocenteCurso();
                    docCurso.ID = (int)drDocentesCursos["id_dictado"];
                    docCurso.IDCurso = (int)drDocentesCursos["id_curso"];
                    docCurso.IDDocente = (int)drDocentesCursos["id_docente"];
                    docCurso.Cargo = (DocenteCurso.TiposCargo)drDocentesCursos["cargo"];

                    string apellido = (string)drDocentesCursos["apellido"];
                    string nombre = (string)drDocentesCursos["nombre"];

                    docCurso.Docente = apellido + " " + nombre;



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
