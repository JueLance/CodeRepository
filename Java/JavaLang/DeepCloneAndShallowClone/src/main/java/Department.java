public class Department implements Cloneable {
    private Integer id;
    private String name;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Department clone() throws CloneNotSupportedException {
        Department cloned = (Department) super.clone();

        return cloned;
    }
}
