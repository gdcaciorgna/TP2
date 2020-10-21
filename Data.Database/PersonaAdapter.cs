using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];

                    DateTime fechaN = (DateTime)drPersonas["fecha_nac"];
                    per.FechaNacimiento = fechaN;

                    per.TipoP = (Persona.TiposPersona)drPersonas["tipo_persona"];

                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];


                    personas.Add(per);

                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;

        }

        public Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];

                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE personas set nombre = @nombre, apellido = @apellido, direccion = @direccion, email = @email, telefono = @telefono, fecha_nac = @fecha_nac, legajo = @legajo, tipo_persona = @tipo_persona, id_plan = @id_plan where id_persona = @id_persona", sqlConn);
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento; //VER ESTO
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoP;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) values (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) select @@identity", sqlConn);
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int, 50).Value = (int)persona.TipoP;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int, 50).Value = persona.IDPlan;



                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }



        public int getTipoPersona(Persona per)
        {
            int tipo;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("select distinct tipo_persona from personas where id_persona = @id_persona", sqlConn);
                cmdUsuario.Parameters.Add("@id_persona", SqlDbType.Int).Value = per.ID;
                SqlDataReader drPersona = cmdUsuario.ExecuteReader();
                drPersona.Read();
                tipo = (int)drPersona["tipo_persona"];
                return tipo;
            }
            catch (Exception Ex)
            {
                Exception exception = new Exception("Error al retornar el tipo de persona.", Ex);
                throw exception;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Persona> GetAllTipo(Persona.TiposPersona tipo_persona)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                int tipo_persona_int = (int)tipo_persona;

                this.OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("select * from personas where tipo_persona = @tip", sqlConn);
                cmdPersona.Parameters.Add("@tip", SqlDbType.Int).Value = tipo_persona_int;
                SqlDataReader drPersonas = cmdPersona.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];

                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];

                    per.Direccion = (string)drPersonas["direccion"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.Email = (string)drPersonas["email"];
                    per.TipoP = (Persona.TiposPersona)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;

        }

    }
    
}
