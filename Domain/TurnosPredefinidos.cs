using Domain.Entities;

namespace Domain
{
    public static class TurnoPredefinido
    {
        public static List<Turno> ObtenerTurnosPredefinidos()
        {
            return new List<Turno>
            {
                new Turno { BloqueReserva = "Mañana", Horario = "08:00 a 09:30", Cupo = 1, Disponible = true },
                new Turno { BloqueReserva = "Mañana", Horario = "09:30 a 11:00", Cupo = 2, Disponible = true },
                new Turno { BloqueReserva = "Mañana", Horario = "11:00 a 12:30", Cupo = 3, Disponible = true },

                new Turno { BloqueReserva = "Tarde", Horario = "12:30 a 14:00", Cupo = 1, Disponible = true },
                new Turno { BloqueReserva = "Tarde", Horario = "14:00 a 15:30", Cupo = 2, Disponible = true },
                new Turno { BloqueReserva = "Tarde", Horario = "15:30 a 17:00", Cupo = 3, Disponible = true },

                new Turno { BloqueReserva = "Noche", Horario = "17:00 a 18:30", Cupo = 1, Disponible = true },
                new Turno { BloqueReserva = "Noche", Horario = "18:30 a 20:00", Cupo = 2, Disponible = true },
                new Turno { BloqueReserva = "Noche", Horario = "20:00 a 21:30", Cupo = 3, Disponible = true }
            };
        }
    }
}



