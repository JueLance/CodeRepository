package cn.rocky;

import java.text.SimpleDateFormat;
import java.util.Date;

public class People {
    public People() {
    }

    public People(int id, String name, Date birthDate) {
        this.id = id;
        this.name = name;
        this.birthdate = birthDate;
    }

    private Integer id;
    private String name;
    private Date birthdate;

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

    public Date getBirthdate() {
        return birthdate;
    }

    public void setBirthdate(Date birthdate) {
        this.birthdate = birthdate;
    }

    @Override
    public String toString() {
        // return super.toString();
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

        return "{\"id\":" + id + ", \"name\":" + name + ", \"birthDate\":" + format.format(birthdate) + "}";
    }
}