public class WorkGameStats {
    private int _completeAmount = 0;

    public int CompleteAmount {
        get => _completeAmount;
        private set => _completeAmount = value;
    }

    public void Increment() {
        CompleteAmount += 1;
    }

    public void Reset() {
        CompleteAmount = 0;
    }
}