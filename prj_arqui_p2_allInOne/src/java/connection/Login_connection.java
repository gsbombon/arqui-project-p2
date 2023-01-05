
package connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class Login_connection {
    static Connection con = null;

    public static Connection RetriveConnection() {
        try {
            Class.forName("com.mysql.jdbc.Driver");
            con = DriverManager.getConnection(
                    "jdbc:mysql://database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com:3306/ProjectArquiDB", "admin", "admin123");
        } catch (Exception e) {
            System.out.println(e);
        }
        return con;
    }
    
    public int loginOrc(String usuario, String contrasena) throws SQLException {
        if (con == null) {
            con = RetriveConnection();
        }
        String sql = "SELECT * FROM usuarios WHERE usuario=? AND pass=?";
        PreparedStatement statement = con.prepareStatement(sql);
        statement.setString(1, usuario);
        statement.setString(2, contrasena);
        ResultSet result = statement.executeQuery();
        int i = 0;
        while (result.next()) {
            i++;
        }
        if (i > 0) {
            return 1;
        } else {
            return 0;
        }
    }
    
    public int insertarUsuarioOrc(String usuario, String password) throws SQLException {
        String sql = "INSERT INTO usuarios(usuario,pass) VALUES (?,?)";
        PreparedStatement statement = con.prepareStatement(sql);
        statement.setString(1, usuario);
        statement.setString(2, password);
        int rowsInserted = statement.executeUpdate();
        if (rowsInserted > 0) {
            return 1;
        }else{
            return 0;
        }
    }
    
}
