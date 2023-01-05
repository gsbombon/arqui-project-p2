package connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import model.Articulo;

public class Article_connection {
    
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
    
    
    public ArrayList<Articulo> listarArticulo() throws SQLException {
        ArrayList<Articulo> articulos = new ArrayList<>();
        String sql = "SELECT * FROM articulo";
        Statement statement = con.createStatement();
        ResultSet result = statement.executeQuery(sql);
        while (result.next()) {
            int codigo = result.getInt(1);
            String nombre = result.getString(2);
            String precio = result.getString(3);
            int stock = result.getInt(4);
            Articulo articulo = new Articulo();
            articulo.setId(codigo);
            articulo.setNombre(nombre);
            articulo.setPrecio(precio);
            articulo.setStock(stock);
            System.out.println(articulo.getId() + "-" + articulo.getNombre() + "-" + articulo.getPrecio() + "-" + articulo.getStock());
            articulos.add(articulo);
        }
        return articulos;
    }
    
    
}
