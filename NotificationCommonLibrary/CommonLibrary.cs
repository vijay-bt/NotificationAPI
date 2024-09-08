namespace NotificationCommonLibrary
{
    public static class CommonLibrary
    {
        public static T GetRandomEnumValue<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));  // Get all values from the enum
            Random random = new Random();
            int index = random.Next(values.Length);    // Generate random index
            return (T)values.GetValue(index);          // Return the random enum value
        }
    }
}
