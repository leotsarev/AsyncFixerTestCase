using System.Threading.Tasks;

namespace AsyncFixerTestCase
{
    class Program
    {
        private static Task Main(string[] args)
        {
            return AwaitSkipped();
        }

        private static Task AwaitSkipped()
        {
            ReturnVoid(); //Expect some kind of warning
            return Task.CompletedTask;
        }

        private static async Task AwaitSkippedInAsync()
        {
            await ReturnVoid();
            ReturnVoid(); // CS4014
        }

        public static Task ReturnVoid()
        {
            //Expect AsyncFixer05
            return Task.FromResult(true);
        }

        public static Task<int> ReturnInt()
        {
            return Task.FromResult(1);
        }

        public static Task ConvertIntToVoid()
        {
            //Expect AsyncFixer05
            var convertIntToVoid = (Task) ReturnInt();
            return convertIntToVoid;
        }
    }
}
