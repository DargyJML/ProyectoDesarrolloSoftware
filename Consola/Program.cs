using System;
using Dominio;
using Persistencia;
using System.Collections.Generic;

namespace Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repomunicipio= new RepositorioMunicipio(new Persistencia.AppContext());
        private static IRepositorioDeportista _repoDeportista= new RepositorioDeportista(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            // En este espacio se llaman las funciones a ejecutar, por ejemplo: listarDeportistas(); 
            //ingresarDatosMun();
            listarMunicipios();
        }

        private static bool crearMunicipio(Municipio mun)
        {            
            bool funciono= _repomunicipio.CrearMunicipio(mun);
            return funciono;
        }

        private static void listarMunicipios()
        {
            IEnumerable<Municipio> municipios=_repomunicipio.ListarMunicipios();
            foreach (var mun in municipios)
            {
                Console.WriteLine(mun.Id +" "+ mun.Nombre);
            }
        }

        private static bool eliminarMunicipio()
        {
            string idMun="";
            Console.WriteLine("Ingrese el id del municipio a borrar");
            idMun=Console.ReadLine();
            bool funciono=_repomunicipio.EliminarMunicipio(int.Parse(idMun));
            return funciono;
        }

        private static bool actualizarMunicipio()
        {
            string newIdMun="";
            string newNomMun="";
            Console.WriteLine("Ingrese el id del municipio a actualizar");
            newIdMun=Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo nombre para el municipio de id "+newIdMun);
            newNomMun=Console.ReadLine();            
            var municipio= new Municipio
            {
                Id=int.Parse(newIdMun),
                Nombre=newNomMun
            };
            bool funciono= _repomunicipio.ActualizarMunicipio(municipio);
            return funciono;
        }

        private static void buscarMunicipio()
        {
            string numMun="";
            Console.WriteLine("Ingrese el id del municipio que desea buscar");
            numMun=Console.ReadLine();            
            var mun= _repomunicipio.BuscarMunicipio(int.Parse(numMun));
            if(mun!=null)
            {
                Console.WriteLine(mun.Id+" "+mun.Nombre);
            }
            else
            {
                Console.WriteLine("Municipio no encontrado");
            }
        }
        private static void ingresarDatosMun()
        {
            string mun="";
            Console.WriteLine("Ingrese el nombre del municipio que desea registrar");
            mun=Console.ReadLine();
            var muni= new Municipio
            {
                Nombre=mun
            };
            bool f=crearMunicipio(muni);
            if(f)
            {
                Console.WriteLine("Municipio adicionado con exito");
            }
            else
            {
                 Console.WriteLine("Se ha presentado una falla en al adicionar el municipio");
            }

        }

        /////////////////////////////////////////////////////////   

        private static bool crearDeportista(Deportista dep)
        {            
            bool funciono= _repoDeportista.CrearDeportista(dep);
            return funciono;
        }

        private static void listarDeportistas()
        {
            IEnumerable<Deportista> Deportistas=_repoDeportista.ListarDeportistas();
            foreach (var dep in Deportistas)
            {
                Console.WriteLine(dep.Id +" "+ dep.Nombres+" "+dep.Apellidos);
            }
        }

        private static bool eliminarDeportista()
        {
            string iddep="";
            Console.WriteLine("Ingrese el id del Deportista a borrar");
            iddep=Console.ReadLine();
            bool funciono=_repoDeportista.EliminarDeportista(int.Parse(iddep));
            return funciono;
        }

        private static bool actualizarDeportista()
        {
            string newIddep="";
            string newNomdep="";
            string depApel="";
            string depIdentl="";
            string depTel="";
            string depDir="";
            string depEma="";
            string depGen="";
            string depRh="";
            string depFech="";
            string depEquipoId="";

            Console.WriteLine("Ingrese el id del Deportista a actualizar");
            newIddep=Console.ReadLine();
            Console.WriteLine("Ingrese los datos correspondientes para el deportista de id "+newIddep+"\nNombres");
            newNomdep=Console.ReadLine();
            Console.WriteLine("Apellidos");
            depApel=Console.ReadLine();
            Console.WriteLine("Identificación");
            depIdentl=Console.ReadLine();
            Console.WriteLine("Teléfono");
            depTel=Console.ReadLine();
            Console.WriteLine("Dirección");
            depDir=Console.ReadLine();
            Console.WriteLine("Email");
            depEma=Console.ReadLine();
            Console.WriteLine("Género");
            depGen=Console.ReadLine();
            Console.WriteLine("RH");
            depRh=Console.ReadLine();
            Console.WriteLine("Fecha de nacimiento aa-mm-dd");
            depFech=Console.ReadLine();
            Console.WriteLine("ID del equipo al que pertenece");
            depEquipoId=Console.ReadLine();


            var Deportista= new Deportista
            {
                Id=int.Parse(newIddep),
                Nombres=newNomdep,
                Apellidos=depApel,
                Identificacion=depIdentl,
                Telefono=depTel,
                Direccion=depDir,
                Email=depEma,
                Genero=depGen,
                Rh=depRh,
                FechaNacimiento=DateTime.Parse(depFech),
                EquipoId=int.Parse(depEquipoId)

            };
            bool funciono= _repoDeportista.ActualizarDeportista(Deportista);
            return funciono;
        }

        private static void buscarDeportista()
        {
            string numdep="";
            Console.WriteLine("Ingrese el id del Deportista que desea buscar");
            numdep=Console.ReadLine();            
            var dep= _repoDeportista.BuscarDeportista(int.Parse(numdep));
            if(dep!=null)
            {
                Console.WriteLine(dep.Id+" "+dep.Nombres+" "+dep.Apellidos);
            }
            else
            {
                Console.WriteLine("Deportista no encontrado");
            }
        }
        private static void ingresarDatosdep()
        {
            string depNomb="";
            string depApel="";
            string depIdentl="";
            string depTel="";
            string depDir="";
            string depEma="";
            string depGen="";
            string depRh="";
            string depFech="";
            string depEquipoId="";

            Console.WriteLine("A continuación ingrese los datos del deportista a crear");
            Console.WriteLine("Nombres");
            depNomb=Console.ReadLine();
            Console.WriteLine("Apellidos");
            depApel=Console.ReadLine();
            Console.WriteLine("Identificación");
            depIdentl=Console.ReadLine();
            Console.WriteLine("Teléfono");
            depTel=Console.ReadLine();
            Console.WriteLine("Dirección");
            depDir=Console.ReadLine();
            Console.WriteLine("Email");
            depEma=Console.ReadLine();
            Console.WriteLine("Género");
            depGen=Console.ReadLine();
            Console.WriteLine("RH");
            depRh=Console.ReadLine();
            Console.WriteLine("Fecha de nacimiento aa-mm-dd");
            depFech=Console.ReadLine();
            Console.WriteLine("ID del equipo al que pertenece");
            depEquipoId=Console.ReadLine();

            var depi= new Deportista
            {
                Nombres=depNomb,
                Apellidos=depApel,
                Identificacion=depIdentl,
                Telefono=depTel,
                Direccion=depDir,
                Email=depEma,
                Genero=depGen,
                Rh=depRh,
                FechaNacimiento=DateTime.Parse(depFech),
                EquipoId=int.Parse(depEquipoId)

            };
            bool f=crearDeportista(depi);
            if(f)
            {
                Console.WriteLine("Deportista adicionado con exito");
            }
            else
            {
                 Console.WriteLine("Se ha presentado una falla en al adicionar el deportista");
            }

        }
    }    
}
