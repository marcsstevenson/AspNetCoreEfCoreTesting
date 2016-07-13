namespace Generic.Framework.Helpers
{
    public abstract class Query
    {
        protected Query()
        {
            this.Skip = 0;
            this.Take = 20;
        }

        /// <summary>
        /// The number of records to skip
        /// </summary>
        public int? Skip { get; set; }
        /// <summary>
        /// The number of records to take
        /// </summary>
        public int? Take { get; set; }
    }
}