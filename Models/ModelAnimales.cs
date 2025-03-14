﻿namespace AppCuidandoPatitas.Models
{
    public class ModelAnimales
    {
        private int _animal_id;
        private int _especie_id;
        private int _raza_id;
        private string _animal_nombre;
        private char _animal_sexo;
        private int _animal_edad;
        private DateTime _animal_fecha_nacimiento;
        private decimal _animal_peso;
        private int _animal_castrado;
        private string _animal_descripcion;
        private DateTime _fecha_alta;
        private int _user_alta;
        private DateTime _fecha_modificacion;
        private int _user_modificacion;
        private DateTime _fecha_baja;
        private int _user_baja;

        public int AnimalId { get => _animal_id; set => _animal_id = value; }
        public int EspecieId { get => _especie_id; set => _especie_id = value; }
        public int RazaId { get => _raza_id; set => _raza_id = value; }
        public string AnimalNombre { get => _animal_nombre; set => _animal_nombre = value; }
        public char AnimalSexo { get => _animal_sexo; set => _animal_sexo = value; }
        public int AnimalEdad { get => _animal_edad; set => _animal_edad = value; }
        public DateTime AnimalFechaNacimiento { get => _animal_fecha_nacimiento; set => _animal_fecha_nacimiento = value; }
        public decimal AnimalPeso { get => _animal_peso; set => _animal_peso = value; }
        public int AnimalCastrado { get => _animal_castrado; set => _animal_castrado = value; }
        public string AnimalDescripcion { get => _animal_descripcion; set => _animal_descripcion = value; }
        public DateTime FechaAlta { get => _fecha_alta; set => _fecha_alta = value; }
        public int UserAlta { get => _user_alta; set => _user_alta = value; }
        public DateTime FechaModificacion { get => _fecha_modificacion; set => _fecha_modificacion = value; }
        public int UserModificacion { get => _user_modificacion; set => _user_modificacion = value; }
        public DateTime FechaBaja { get => _fecha_baja; set => _fecha_baja = value; }
        public int UserBaja { get => _user_baja; set => _user_baja = value; }
    }
}
