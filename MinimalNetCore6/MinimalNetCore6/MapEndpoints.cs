using Microsoft.AspNetCore.Mvc;

namespace MinimalNetCore6
{
    public static class MapEndpoints
    {
        public static WebApplication MapArray(this WebApplication app)
        {
            app.MapPost("Sort/", ([FromBody] ArrayModel model) =>
            {
                var sortedNumber = model.ArrayNumber!.ToArray();
                var id = model.SortType;
                if (id == 0)
                {
                    Array.Sort(sortedNumber);
                }
                else if (id == 1)
                {
                    for (int i = 0; i < sortedNumber.Length; i++)
                    {
                        for (int j = i + 1; j < sortedNumber.Length; j++)
                        {
                            if (sortedNumber[i] < sortedNumber[j])
                            {
                                int temp = sortedNumber[i];
                                sortedNumber[i] = sortedNumber[j];
                                sortedNumber[j] = temp;
                            }
                        }
                    }
                }
                return sortedNumber;
            });
            return app;
        }
    }
}
