
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Dominio;

public class Sistema
{
    private static Sistema instancia;
    private Empleado empleadoLogueado;
    private List<Vacuna> listaVacunas = new List<Vacuna>();
    private List<Ganado> listaGanado = new List<Ganado>();
    private List<Empleado> listaEmpleados = new List<Empleado>();
    private List<Tarea> listaTareas = new List<Tarea>();
    private List<Potrero> potreros = new List<Potrero>();
    static void Main(string[] args)
    {
        Sistema sistema = Sistema.Instancia;
        sistema.InicializarPrecarga();
        Console.WriteLine("Hola.");

    }

    public void InicializarPrecarga()
    {
        #region Nuevas instancias vacunas

        AltaVacuna("Covexin", "Vacuna contra clostridios", "Clostridium");
        AltaVacuna("Barbervax", "Vacuna contra Haemonchus Contortus", "Haemonchus Contortus");
        AltaVacuna("Bravoxin", "Vacuna para el control de infecciones bacterianas", "Pasteurella");
        AltaVacuna("Heptavac P", "Vacuna contra varias infecciones bacterianas en ovinos", "Pasteurella, Clostridium");
        AltaVacuna("Ovivac P", "Vacuna para prevenir enfermedades en ovinos", "Clostridium, Mannheimia haemolytica");
        AltaVacuna("Bovilis", "Vacuna contra la diarrea viral bovina", "Virus de la diarrea viral bovina");
        AltaVacuna("Tribovax 10", "Vacuna para proteger contra 10 cepas de clostridios", "Clostridium");
        AltaVacuna("Ultrabac 7", "Vacuna para prevenir siete enfermedades comunes en bovinos", "Clostridium");
        AltaVacuna("Cydectin", "Vacuna para el control de parásitos internos y externos", "Parásitos diversos");
        AltaVacuna("Footvax", "Vacuna para prevenir la podredumbre del pie en ovinos", "Bacterias del pie podrido");

        #endregion

        #region Nuevas instancias capataz
        AltaCapataz("Carlos Jiménez", "carlos.jimenez@example.com", "password123", new DateTime(2023, 12, 1));
        AltaCapataz("Luisa Martínez", "luisa.martinez@example.com", "password456", new DateTime(2023, 12, 15));
        #endregion

        #region Nuevos instancias empleados

        AltaPeon("Carlos Jiménez", "carlos.jimenez@exatmple.com", "securePassword01", new DateTime(2023, 12, 1), true);
        AltaPeon("Ana Torres", "ana.torres@example.com", "securePassword02", new DateTime(2023, 12, 2), false);
        AltaPeon("Roberto Gómez", "roberto.gomez@example.com", "securePassword03", new DateTime(2023, 12, 3), true);
        AltaPeon("María Rodríguez", "maria.rodriguez@example.com", "securePassword04", new DateTime(2023, 12, 4), false);
        AltaPeon("Luis Alvarez", "luis.alvarez@example.com", "securePassword05", new DateTime(2023, 12, 5), true);
        AltaPeon("Sofía Castro", "sofia.castro@example.com", "securePassword06", new DateTime(2023, 12, 6), false);
        AltaPeon("Miguel Angel López", "miguel.lopez@example.com", "securePassword07", new DateTime(2023, 12, 7), true);
        AltaPeon("Julia Fernández", "julia.fernandez@example.com", "securePassword08", new DateTime(2023, 12, 8), false);
        AltaPeon("Diego Morales", "diego.morales@example.com", "securePassword09", new DateTime(2023, 12, 9), true);
        AltaPeon("Isabel Martínez", "isabel.martinez@example.com", "securePassword10", new DateTime(2023, 12, 10), false);


        #endregion

        #region Nuevas instancias bovinos

        AltaBovino("001A", DateTime.Now.AddMonths(-1), 1200, 300, TipoSexo.Hembra, 150, false, "Brahman", TipoAlimentacion.Grano);
        AltaBovino("002B", DateTime.Now.AddMonths(-2), 1250, 310, TipoSexo.Macho, 160, true, "Angus", TipoAlimentacion.Pastura);
        AltaBovino("003C", DateTime.Now.AddMonths(-2), 1300, 320, TipoSexo.Macho, 165, false, "Hereford", TipoAlimentacion.Grano);
        AltaBovino("004D", DateTime.Now.AddYears(-1), 1000, 250, TipoSexo.Hembra, 450, true, "Nelore", TipoAlimentacion.Pastura);
        AltaBovino("005E", DateTime.Now.AddYears(-2), 1100, 270, TipoSexo.Macho, 500, false, "Gyr", TipoAlimentacion.Grano);
        AltaBovino("006F", DateTime.Now.AddYears(-3), 1150, 280, TipoSexo.Hembra, 470, true, "Guzerá", TipoAlimentacion.Pastura);
        AltaBovino("007G", DateTime.Now.AddYears(-4), 900, 220, TipoSexo.Macho, 400, false, "Charolais", TipoAlimentacion.Grano);
        AltaBovino("008H", DateTime.Now.AddYears(-1), 950, 230, TipoSexo.Hembra, 440, true, "Simmental", TipoAlimentacion.Pastura);
        AltaBovino("009I", DateTime.Now.AddYears(-2), 1050, 260, TipoSexo.Macho, 480, false, "Limousin", TipoAlimentacion.Grano);
        AltaBovino("010J", DateTime.Now.AddYears(-3), 1200, 290, TipoSexo.Hembra, 520, true, "Santa Gertrudis", TipoAlimentacion.Pastura);
        AltaBovino("011K", DateTime.Now.AddYears(-4), 1100, 275, TipoSexo.Macho, 510, false, "Brahman", TipoAlimentacion.Grano);
        AltaBovino("012L", DateTime.Now.AddYears(-5), 1300, 320, TipoSexo.Hembra, 540, true, "Angus", TipoAlimentacion.Pastura);
        AltaBovino("013M", DateTime.Now.AddYears(-1), 950, 240, TipoSexo.Macho, 450, false, "Hereford", TipoAlimentacion.Grano);
        AltaBovino("014N", DateTime.Now.AddYears(-2), 1250, 305, TipoSexo.Hembra, 530, true, "Nelore", TipoAlimentacion.Pastura);
        AltaBovino("015O", DateTime.Now.AddYears(-3), 1150, 285, TipoSexo.Macho, 500, false, "Gyr", TipoAlimentacion.Grano);
        #endregion

        AltaOvino("OV001", DateTime.Now.AddMonths(-1), 150, 50, TipoSexo.Hembra, 25, false, "Merino", 3.0f);
        AltaOvino("OV002", DateTime.Now.AddMonths(-2), 160, 55, TipoSexo.Macho, 30, true, "Corriedale", 3.5f);
        AltaOvino("OV003", DateTime.Now.AddMonths(-2), 155, 52, TipoSexo.Hembra, 28, false, "Texel", 3.2f);
        AltaOvino("OV004", DateTime.Now.AddYears(-1), 140, 45, TipoSexo.Macho, 40, true, "Dorper", 4.0f);
        AltaOvino("OV005", DateTime.Now.AddYears(-2), 145, 48, TipoSexo.Hembra, 35, false, "Suffolk", 3.8f);
        AltaOvino("OV006", DateTime.Now.AddYears(-3), 150, 50, TipoSexo.Macho, 42, true, "Rambouillet", 4.2f);
        AltaOvino("OV007", DateTime.Now.AddYears(-4), 160, 55, TipoSexo.Hembra, 38, false, "Merino", 3.5f);
        AltaOvino("OV008", DateTime.Now.AddYears(-1), 155, 50, TipoSexo.Macho, 45, true, "Dorper", 4.1f);
        AltaOvino("OV009", DateTime.Now.AddYears(-2), 150, 48, TipoSexo.Hembra, 37, false, "Corriedale", 3.7f);
        AltaOvino("OV010", DateTime.Now.AddYears(-3), 145, 47, TipoSexo.Macho, 39, true, "Texel", 3.9f);
        AltaOvino("OV011", DateTime.Now.AddYears(-4), 158, 53, TipoSexo.Hembra, 41, false, "Suffolk", 4.0f);
        AltaOvino("OV012", DateTime.Now.AddYears(-5), 152, 49, TipoSexo.Macho, 36, true, "Rambouillet", 3.6f);
        AltaOvino("OV013", DateTime.Now.AddYears(-1), 160, 55, TipoSexo.Hembra, 43, false, "Merino", 4.3f);
        AltaOvino("OV014", DateTime.Now.AddYears(-2), 155, 50, TipoSexo.Macho, 40, true, "Dorper", 4.1f);
        AltaOvino("OV015", DateTime.Now.AddYears(-3), 150, 48, TipoSexo.Hembra, 35, false, "Corriedale", 3.5f);

        AltaPotrero("Pastura baja para ovinos", 5.5f, 4);
        AltaPotrero("Pastura mejorada para bovinos", 7.0f, 6);
        AltaPotrero("Zona de crianza mixta", 9.0f, 8);
        AltaPotrero("Área de engorde bovino", 8.5f, 10);
        AltaPotrero("Potrero de recuperación ovina", 6.0f, 5);
        AltaPotrero("Campo de entrenamiento bovino", 7.5f, 7);
        AltaPotrero("Área de descanso mixto", 10.0f, 9);
        AltaPotrero("Sector de parto para ovinos", 5.0f, 4);
        AltaPotrero("Zona de alimentación suplementaria", 8.0f, 10);
        AltaPotrero("Campo joven para novillos", 9.5f, 8);


    }

    #region Singleton
    public static Sistema Instancia
    {
        get
        {
            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }
    }
    #endregion

    #region Ganado


    /*public List<Ganado> ListarGanado
        {
            get => listaGanado;
        }*/

    public List<Ganado> ListarGanado()
    {
        return listaGanado;
    }

    public Ganado BuscarGanado(string codCaravana)
    {
        try
        {
            foreach (Ganado ganado in listaGanado)
            {
                if (ganado.CodCaravana == codCaravana)
                {
                    return ganado;
                }
            }
            return null;
        }
        catch (Exception e)
        {
            throw new Exception("Ocurrio un error al buscar el ganado");
        }
    }

    public void AltaOvino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, float pesoLana)
    {
        try
        {
            Ovino ovino = new Ovino(codCaravana, fechaNacimiento, costoAdquisicion, costoAlimentacion, sexo, peso, esHibrido, raza, pesoLana);
            ovino.Validar();
            VerificarExistenciaGanado(ovino);
            listaGanado.Add(ovino);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void AltaBovino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, TipoAlimentacion alimentacion)
    {
        try
        {
            Bovino bovino = new Bovino(codCaravana, fechaNacimiento, costoAdquisicion, costoAlimentacion,sexo, peso, esHibrido, raza, TipoAlimentacion.Grano);
            bovino.Validar();
            VerificarExistenciaGanado(bovino);
            listaGanado.Add(bovino);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModificarOvino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, float pesoLana)
    {
        try
        {
            Ovino ovino = (Ovino)BuscarGanado(codCaravana);
            if (ovino == null)
            {
                throw new Exception("El ovino no existe");
            }
            ovino.FechaNacimiento = fechaNacimiento;
            ovino.CostoAdquisicion = costoAdquisicion;
            ovino.CostoAlimentacion = costoAlimentacion;
            ovino.Peso = peso;
            ovino.EsHibrido = esHibrido;
            ovino.Raza = raza;
            ovino.PesoLana = pesoLana;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModificarBovino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, TipoAlimentacion alimentacion)
    {
        try
        {
            Bovino bovino = (Bovino)BuscarGanado(codCaravana);
            if (bovino == null)
            {
                throw new Exception("El bovino no existe");
            }
            bovino.FechaNacimiento = fechaNacimiento;
            bovino.CostoAdquisicion = costoAdquisicion;
            bovino.CostoAlimentacion = costoAlimentacion;
            bovino.Peso = peso;
            bovino.EsHibrido = esHibrido;
            bovino.Raza = raza;
            bovino.Alimentacion = alimentacion;
        }
        catch (Exception e)
        {
            throw e;
        }

    }

    public List<Vacunacion> ObtenerVacunacionesGanado(string codCaravana)
    {
        try
        {
            Ganado ganado = BuscarGanado(codCaravana);
            if (ganado == null)
            {
                throw new Exception("El ganado no existe");
            }
            return ganado.ListaVacunaciones;
        }
        catch (Exception e)
        {
            throw new Exception("Ocurrio un error al obtener las vacunaciones del ganado");
        }
    }

    public void AltaVacunacion(string nombreVacuna, DateTime fechaVacunacion, string codCaravana)
    {
        try
        {
            Ganado ganado = BuscarGanado(codCaravana);
            Vacuna vacuna = BuscarVacuna(nombreVacuna);

            if (ganado == null) throw new Exception("El ganado no existe");
            if (vacuna == null) throw new Exception("La vacuna no existe");

            if (fechaVacunacion < ganado.FechaNacimiento) throw new Exception("La fecha de vacunacion no puede ser anterior a la fecha de nacimiento del ganado");

            if (ganado.esVacunable())
            {
                ganado.AgregarVacunacion(vacuna, fechaVacunacion);
            }
            else
            {
                throw new Exception("El ganado no es vacunable");
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region preciosVenta

    public void DefinirPrecioKgPieOvino(float value)
    {
        Ovino.PrecioKgPie = value;
    }

    public void DefinirPrecioKgLana(float value)
    {
        Ovino.PrecioKgLana = value;
    }

    public void DefinirPrecioKgPieBovino(float value)
    {
        Bovino.PrecioKgPie = value;
    }

    #endregion

    #region Vacunas

    public List<Vacuna> ListaVacunas
    {
        get => listaVacunas;
    }

    public void AltaVacuna(string nombre, string descripcion, string patogeno)
    {
        try
        {
            Vacuna vacuna = new Vacuna(nombre, descripcion, patogeno);
            vacuna.Validar();
            VerificarExistenciaVacuna(vacuna);
            listaVacunas.Add(vacuna);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModificarVacuna(string nombre, string descripcion, string patogeno)
    {
        try
        {
            Vacuna vacuna = BuscarVacuna(nombre);
            if (vacuna == null)
            {
                throw new Exception("La vacuna no existe");
            }
            vacuna.Description = descripcion;
            vacuna.Patogeno = patogeno;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public Vacuna BuscarVacuna(string nombreVacuna)
    {
        try
        {
            foreach (Vacuna vacuna in listaVacunas)
            {
                if (vacuna.Nombre == nombreVacuna)
                {
                    return vacuna;
                }
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception("Ocurrio un error al buscar la vacuna");
        }
    }

    public List<Vacunacion> ObtenerVacunaciones()
    {
        try
        {
            List<Vacunacion> vacunaciones = new List<Vacunacion>();
            foreach (Ganado ganado in listaGanado)
            {
                foreach (Vacunacion vacunacion in ganado.ListaVacunaciones)
                {
                    vacunaciones.Add(vacunacion);
                }
            }
            return vacunaciones;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    #endregion

    #region Tareas

    public Tarea BuscarTarea(int id)
    {
        foreach (Tarea tarea in listaTareas)
        {
            if (id == tarea.Id)
            {
                return tarea;
            }
        }
        return null;
    }

    public void AltaTarea(string descripcion, DateTime fechaEstimada, string emailCapataz, string emailPeon)
    {
        try
        {
            Empleado capataz = BuscarEmpleado(emailCapataz);
            Peon peon = BuscarEmpleado(emailPeon) as Peon;
            if (capataz == null)
            {
                throw new Exception("El capataz no existe");
            }

            if (capataz.GetType() != typeof(Capataz))
            {
                throw new Exception("El supervisor no es un capataz");
            }

            if (peon.GetType() != typeof(Peon))
            {
                throw new Exception("El responsable no es un peon");
            }

            Tarea tarea = new Tarea(descripcion, fechaEstimada, capataz as Capataz, peon.Email);
            tarea.Validar();
            peon.AsignarTarea(tarea);
            listaTareas.Add(tarea);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void AsignarTarea(string email, int id)
    {
        string minEmail = email.ToLower();
        Empleado empleado = BuscarEmpleado(email);
        Peon peon;
        if (empleado.GetType() == typeof(Peon))
        {
            peon = empleado as Peon;
        }
        else
        {
            throw new Exception("El empleado no es un peon");
        }

        Tarea tarea = BuscarTarea(id);
        if (tarea == null)
        {
            throw new Exception("La tarea no existe");
        }
        peon.AsignarTarea(tarea);
    }

    public List<Tarea> ListarTareas() //potencial de comprimir
    {
        return listaTareas;
    }

    public List<Tarea> ObtenerTareasPeon(string email)
    {
        try
        {
            Empleado empleado = BuscarEmpleado(email);
            Peon peon;
            if (empleado == null)
            {
                throw new Exception("Peon no encontrado");
            }
            if (empleado.GetType() == typeof(Peon))
            {
                peon = empleado as Peon;
                return peon.Tareas;
            }
            return null;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void CerrarTarea(int id, string email, string comentario)
    {

        string minEmail = email.ToLower();
        try
        {
            Tarea tarea = BuscarTarea(id);
            Empleado empleado = BuscarEmpleado(email);

            // si el empleado es capataz del responsable de la tarea, o si es el responsable, puede cerrarla
            if (empleado.GetType() == typeof(Capataz) || empleado.Email == tarea.EmailResponsable)
            {
                tarea.CerrarTarea(comentario);
            }
            else
            {
                throw new Exception("No tiene permisos para cerrar la tarea");
            }


        }
        catch (Exception mensaje)
        {
            throw mensaje;
        }
    }

    #endregion

    #region Empleados

    public Empleado? BuscarEmpleado(string email)
    {
        string minEmail = email.ToLower();
        foreach (Empleado empleado in listaEmpleados)
        {
            if (minEmail == empleado.Email)
            {
                return empleado;
            }
        }
        return null;
    }

    public void AltaCapataz(string nombre, string email, string password, DateTime fechaIngreso)
    {
        try
        {
            Capataz capataz = new Capataz(nombre, email, password, fechaIngreso);
            capataz.Validar();
            VerificarExistenciaEmpleado(capataz);
            listaEmpleados.Add(capataz);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void AltaPeon(string nombre, string email, string password,DateTime fechaInicio, bool esResidente)
    {
        try
        {
            Peon peon = new Peon(nombre, email, password, fechaInicio, esResidente);
            peon.Validar();
            VerificarExistenciaEmpleado(peon);
            listaEmpleados.Add(peon);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModificarEmpleado(string email, string nombre)
    {
        try
        {
            Empleado empleado = BuscarEmpleado(email);
            if (empleado == null)
            {
                throw new Exception("El empleado no existe");
            }
            empleado.Nombre = nombre;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModicarEmpleado(string email, string nombre, bool esResidente)
    {
        try
        {
            Empleado peon = BuscarEmpleado(email);
            if (peon == null)
            {
                throw new Exception("El empleado no existe");
            }
            peon.Nombre = nombre;
            if (peon.GetType() == typeof(Peon))
            {
                // peon. = esResidente;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void VincularPeonCapataz(string emailPeon, string emailCapataz)
    {
        try
        {

            Empleado peon = BuscarEmpleado(emailPeon);
            Empleado capataz = BuscarEmpleado(emailCapataz);

            if (peon == null || capataz == null)
            {
                throw new Exception("El empleado no existe");
            }

            if (peon.GetType() == typeof(Peon) && capataz.GetType() == typeof(Capataz))
            {
                //capataz.AsignarPeon(peon);
            }
            else
            {
                throw new Exception("El empleado no es un peon o capataz");
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void DesvincularPeonCapataz(string emailPeon, string emailCapataz)
    {
        try
        {
            Empleado peon = BuscarEmpleado(emailPeon);
            Empleado capataz = BuscarEmpleado(emailCapataz);

            if (peon == null || capataz == null)
            {
                throw new Exception("El empleado no existe");
            }

            if (peon.GetType() == typeof(Peon) && capataz.GetType() == typeof(Capataz))
            {
                //capataz.PersonasACargo.Remove(peon);
            }
            else
            {
                throw new Exception("El empleado no es un peon o capataz");
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void CambiarPassword(string email, string password)
    {
        try
        {
            Empleado empleado = BuscarEmpleado(email);
            if (empleado == null)
            {
                throw new Exception("El empleado no existe");
            }
            empleado.Password = password;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    public bool Login(string email, string password)
    {
        try
        {
            Empleado empleado = BuscarEmpleado(email);
            if (empleado == null)
            {
                throw new Exception("El empleado no existe");
            }

            if (empleado.ComprobarPassword(password))
            {
                empleadoLogueado = empleado;
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception("Ocurrio un error al realizar login");
        }
    }

    public void CerrarSesion()
    {
        empleadoLogueado = null;
    }


    public List<Peon> MostrarPeonPorCapataz(string email)
    {
        Empleado empleado = BuscarEmpleado(email);
        Capataz capataz;
        if (empleado == null)
        {
            throw new Exception("Capataz no encontrado");
        }
        if (empleado.GetType() == typeof(Capataz))
        {
            capataz = empleado as Capataz;
            return capataz.PersonasACargo;
        }
        return null;
    }

    public List<Capataz> ObtenerCapatazSegunPeon(string email)//tiene potencial
    {
        try
        {
            List<Capataz> capataces = new List<Capataz>();
            foreach (Empleado empleado in listaEmpleados)
            {
                if (empleado.GetType() == typeof(Capataz))
                {
                    Capataz capataz = (Capataz)empleado;
                    foreach (Peon peon in capataz.PersonasACargo)
                    {
                        if (peon.Email == email)
                        {
                            capataces.Add(capataz);
                        }
                    }
                }
            }

            return capataces;
        }
        catch (Exception e)
        {
            throw e;
        }
    }


    #endregion

    #region Potrero

    public void AltaPotrero(string descripcion, float cantHectareas, int capacidadMaxima)
    {
        try
        {
            Potrero potrero = new Potrero(descripcion, cantHectareas, capacidadMaxima);
            potrero.Validar();
            potreros.Add(potrero);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public List<Potrero> ObtenerPotreroSegunHectareas(float cantidadhectareas, int capacidad)
    {

        try
        {
            List<Potrero> aux = new List<Potrero>();
            foreach (Potrero unPotrero in potreros)
            {
                if (cantidadhectareas == null || capacidad == null)
                {
                    throw new Exception("El potrero no existe");
                }
                if (unPotrero.CantidadHectareas > cantidadhectareas && unPotrero.CapacidadMaxima > capacidad)
                {
                    aux.Add(unPotrero);
                }
            }

            return aux;
        }
        catch (Exception mensaje)
        {
            throw mensaje;
        }
    }


    public void AsingnarPotrero(string codCaravana, int potreroId)
    {
        try
        {
            Ganado ganado = BuscarGanado(codCaravana);
            Potrero potrero = BuscarPotrero(potreroId);
            if (potrero == null) throw new Exception("Potrero inválido");

            if (ganado == null) throw new Exception("Ganado inválido");

            if (!ganado.EsLibre()) throw new Exception("Ya está asignado");
            if (potrero.ListaGanados.Count >= potrero.CapacidadMaxima) throw new Exception("Potrero en su capacidad máxima");
            ganado.AsignarPotrero(potrero);
            potrero.AsginarGanado(ganado);
        }
        catch (Exception mensaje)
        {
            throw mensaje;
        }


    }

    public Potrero BuscarPotrero(int id)
    {
        try
        {
            foreach (Potrero unPotrero in potreros)
            {
                if (id == unPotrero.Id)
                {
                    return unPotrero;
                }

            }
            throw new Exception("No se encontró potrero");
        }
        catch (Exception mensaje)
        {
            throw mensaje;
        }
    }


    #endregion

    #region Validaciones
    public void VerificarExistenciaEmpleado(Empleado nuevoEmpleado)
    {
        string minEmail = nuevoEmpleado.Email.ToLower();

        foreach (Empleado empleado in listaEmpleados)
        {
            if (empleado.Email != null && empleado.Email.ToLower() == minEmail)
            {
                throw new Exception("Ya está registrado");
            }
        }
    }

    public void VerificarExistenciaGanado(Ganado nuevoGanado)
    {
        foreach (Ganado ganado in listaGanado)
        {
            if (ganado.CodCaravana != null && ganado.CodCaravana == nuevoGanado.CodCaravana)
            {
                throw new Exception("Ya está registrado");
            }
        }
    }

    public void VerificarExistenciaVacuna(Vacuna nuevaVacuna)
    {
        foreach (Vacuna vacuna in listaVacunas)
        {
            if (vacuna.Nombre != null && vacuna.Nombre == nuevaVacuna.Nombre)
            {
                throw new Exception("Ya está registrado");
            }
        }
    }
    #endregion

    public List<Empleado> ObtenerEmpleadosGenerales()
    {
        return listaEmpleados;
    }

    // AltaPotrero *
    // BuscarPotrero @
    // ModificarPotrero
    // CalcularGanancia (NO IMPLEMENTAR) 
    // MostrarGanadoPotrero @
    // ObtenerPotreroSegunHectareas *
}
