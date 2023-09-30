namespace Pro401.DTO.VehiculoDTO
{
    public class VehiculoCreateDTO
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }
        public string? Color { get; set; }
        public int CarroceriaId { get; set; }

    }
}
