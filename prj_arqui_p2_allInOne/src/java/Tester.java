import controller.login_controller;
import java.sql.SQLException;


public class Tester {

    public static void main(String[] args) throws SQLException {
        login_controller logC = new login_controller();
        logC.setUsuario("admin");
        logC.setPass("admin");
        System.out.println(""+logC.ingresar());
    }
    
    
    
}
