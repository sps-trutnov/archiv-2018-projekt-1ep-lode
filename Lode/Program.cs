namespace Lode
{
    class Program
    {
        static void Main(string[] args)
        {
            new Hra(new TextoveRozhrani()).SpustitHru();
            //new Hra().SpustitHru();

            PocitacovyHrac p = new PocitacovyHrac();

            p.RozhodnoutVlastniTah();
        }
    }
}
