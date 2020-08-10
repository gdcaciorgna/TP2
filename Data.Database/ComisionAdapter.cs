using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];

                    comisiones.Add(com);

                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;

        }

        public Business.Entities.Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_plan = @id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];


                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                this.CloseConnection();
            }
            return com;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision = @id", sqlConn);
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

        protected void Update(Comision com)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones set desc_comision = @desc_comision, anio_especialidad = @anio_especialidad, id_comision = @id_comision WHERE id_comision = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = com.ID;
                cmdSave.Parameters.Add("@desc_comisiones", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.VarChar).Value = com.AnioEspecialidad;
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos del comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(Comision com)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into comisiones (desc_comision, anio_especialidad, id_plan) values (@desc_comision, @anio_especialidad, @id_plan) select @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;
                com.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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


        public void Save(Comision com)
        {
            if (com.State == BusinessEntity.States.New)
            {
                this.Insert(com);
            }
            else if (com.State == BusinessEntity.States.Deleted)
            {
                this.Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                this.Update(com);
            }
            com.State = BusinessEntity.States.Unmodified;
        }

    }
}

