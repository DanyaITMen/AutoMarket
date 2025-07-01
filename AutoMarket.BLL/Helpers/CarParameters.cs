namespace AutoMarket.BLL.Helpers
{
    // Успадковуємося від базового класу
    public class CarParameters : QueryStringParameters
    {
        // --- ФІЛЬТРУВАННЯ ---
        // Специфічні поля для фільтрації машин
        public string? Brand { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? Year { get; set; } // Додамо ще фільтр по року
    }
}