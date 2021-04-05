class CacheElement {
    private string name;

    public CacheElement(string n) {
        this.name = n;
    }

    public string getKey() {
        return this.name;
    }
}