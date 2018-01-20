public class App {

    public static void main(String[] args) {
        Employee employee = new Employee();

        Department department = new Department();
        department.setId(1);
        department.setName("原始部门");

        employee.setId(1);
        employee.setName("原始对象");
        employee.setDepartment(department);

        try {
            Employee employee1 = employee.clone();


            department.setName("修改后的部门");

            employee.setDepartment(department);
            employee.setId(2);
            employee.setName("原始对象被修改");


            System.out.println(employee.getId() + " - " + employee1.getId());
            System.out.println(employee.getName() + " - " + employee1.getName());
            System.out.println(employee.getDepartment().getName().toString() + " - " + employee1.getDepartment().getName().toString());


        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }
    }
}
