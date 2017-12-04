package cn.rocky;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.List;

@RestController
public class TestController {


    @GetMapping("/index")
    public ResultData<EmpInfo> test() {

        TestService service = new TestService();
        ResultData<EmpInfo> resultData = new ResultData<>();

        try {
            resultData = service.post2("http://127.0.0.1:9890/getEmployees", new Employee());
            EmpInfo info = resultData.getResult();
            System.out.println(info.getManager());

        } catch (BizException e) {
            e.printStackTrace();
        }

        return resultData;
    }

    @PostMapping("/getEmployees")
    public ResultData<EmpInfo> getEmployees() {
        List<Employee> list = new ArrayList<>();

        Employee employee = new Employee();
        employee.setAge(29);
        employee.setName("JueLance");

        list.add(employee);

        employee.setName("Rokcy");
        employee.setAge(30);

        list.add(employee);

        employee.setName("PengZu");
        employee.setAge(301);
        list.add(employee);

        EmpInfo info = new EmpInfo();
        info.setEmployee(list);
        info.setCount(3);
        info.setName("员工信息表");

        Manager manager = new Manager();
        manager.setAge(9000);
        manager.setName("超级管理员");
        manager.setTitleNo("超级管理员");
        manager.setDepartmentNo("No.1");
        info.setManager(manager);

        ResultData<EmpInfo> resultData = new ResultData<>();
        resultData.setCode(200);
        resultData.setMessage("Successful");
        resultData.setResult(info);
        return resultData;

    }

}
