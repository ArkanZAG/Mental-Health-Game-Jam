namespace DefaultNamespace
{
    public static class WorkingState
    {
        private static bool workingState = false;
        
        public static void SetWorkingState(bool value)
        {
            workingState = value;
        }

        public static bool GetWorkingState()
        {
            return workingState;
        }
    }
}