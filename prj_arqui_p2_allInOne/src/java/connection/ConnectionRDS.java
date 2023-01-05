package connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import model.User;

public class ConnectionRDS {

    static Connection con = null;

    public Connection RetriveConnection() {
        try {
            Class.forName("com.mysql.jdbc.Driver");
            con = DriverManager.getConnection(
                    "jdbc:mysql://database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com:3306/ProjectArquiDB", "admin", "admin123");
        } catch (Exception e) {
            System.out.println(e);
        }
        return con;
    }        

}
