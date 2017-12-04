package cn.rocky;

import lombok.Data;

import java.util.List;

@Data
public class EmpInfo {
    private Integer count;
    private String name;
    private List<Employee> employee;
    private Manager manager;
}
