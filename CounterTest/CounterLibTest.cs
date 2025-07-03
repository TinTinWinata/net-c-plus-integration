using CounterTest.Service;

namespace CounterTest
{
    public class CounterLibTest
    {
        [Fact]
        public void Counter_ShouldReturnCorrectValue_WhenGivenData()
        {
            // Arrange
            int initialValue= 10;
            int totalIncrement = 5;

            // Act
            using (var counter = new CounterWrapper(initialValue))
            {
                // Increment the counter
                for (int i = 0; i < totalIncrement; i++)
                {
                    counter.Increment();
                }
                // Get the current value of the counter
                int finalValue = counter.GetValue();
                
                // Assert
                Assert.Equal(finalValue, initialValue + totalIncrement);
            }
        }
    }
}