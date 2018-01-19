public class Employee implements Cloneable {
    private Integer Id;
    private String name;
    private Department department;

    public Integer getId() {
        return Id;
    }

    public void setId(Integer id) {
        Id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Department getDepartment() {
        return department;
    }

    public void setDepartment(Department department) {
        this.department = department;
    }

    public Employee clone() throws CloneNotSupportedException {
        Employee cloned = (Employee) super.clone();

        cloned.department = (Department) department.clone();

        return cloned;
    }

    @Override
    public String toString() {
        return "id: " + Id + ", name: " + name;
    }
}
