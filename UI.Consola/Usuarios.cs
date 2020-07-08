using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;       // punto 4
using Business.Entities;    // punto 4

namespace UI.Consola
{
    public class Usuarios
    {
        private Business.Logic.UsuarioLogic _UsuarioNegocio;
        public UsuarioLogic UsuarioNegocio
       {
            get
            {
                return this._UsuarioNegocio;
            }

            set
            {
                this._UsuarioNegocio = value;
            }
        }

        public Usuarios()       // constructor
        {
            UsuarioNegocio = new UsuarioLogic();            // punto 5
        }

        public void Menu()
        {
            int seleccion;

            do
            {

                Console.Clear();
                Console.WriteLine("1– Listado General");
                Console.WriteLine("2– Consulta");
                Console.WriteLine("3– Agregar");
                Console.WriteLine("4 - Modificar");
                Console.WriteLine("5 - Eliminar");
                Console.WriteLine("6 - Salir");
                seleccion = int.Parse(Console.ReadLine());

                switch (seleccion)
                {
                    case 1:
                        this.ListadoGeneral();
                        break;
                    case 2:
                        this.Consultar();
                        break;
                    case 3:
                        this.Agregar();
                        break;
                    case 4:
                        this.Modificar();
                        break;
                    case 5:
                        this.Eliminar();
                        break;
                }

            } while (seleccion != 6);

                    
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.ReadLine();
        }

        public void MostrarDatos(Usuario pUsr)
        {
            Console.WriteLine("Usuario: {0}", pUsr.ID);
            Console.WriteLine("\t\tNombre: {0}", pUsr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", pUsr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", pUsr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", pUsr.Clave);
            Console.WriteLine("\t\tEmail: {0}", pUsr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", pUsr.Habilitado);
            Console.WriteLine();
            //Console.ReadLine();
        }

        
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch(FormatException)
            {
                Console.WriteLine("La ID ingresada debe ser un número entero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese Nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese Habilitación de usuario (1 = Sí; otro = No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);

            }
            catch(FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        
        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitación de usuario (1 = Sí; otro = No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);

            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        /*
        public void MostrarDatos()
        */
    }
}
