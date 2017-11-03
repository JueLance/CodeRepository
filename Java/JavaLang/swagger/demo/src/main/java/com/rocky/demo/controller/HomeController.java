package com.rocky.demo.controller;

import io.swagger.annotations.ApiImplicitParam;
import io.swagger.annotations.ApiOperation;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HomeController {

    @ApiOperation(value="获取用户列表", notes="")
    @ApiImplicitParam(name = "id", value = "用户ID", required = true, dataType = "Long")
    @RequestMapping(value = "/hello/{id}")
    public String Hello(String id) {
        return "Hello from demo @ Server";

    }

    @ApiOperation(value="首页", notes="")
    @RequestMapping(value = "/index")
    public String index() {
        return "Hello from demo @ Server";

    }
}
