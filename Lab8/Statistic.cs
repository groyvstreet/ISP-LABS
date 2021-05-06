namespace Lab8
{
    class Statistic
    {
        public ulong AutoThefts { private set; get; }
        public ulong Treatments { private set; get; }
        public ulong Arrest { private set; get; }

        public void RaiseAutoThefts()
        {
            AutoThefts++;
        }

        public void RaiseTreatments()
        {
            Treatments++;
        }

        public void RaiseArrest()
        {
            Arrest++;
        }
    }
}
