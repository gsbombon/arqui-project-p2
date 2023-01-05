package connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import model.Cliente;

public class Facturation_connection {

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
    
    public void Conectar(){
        if (con == null) {
            this.con = RetriveConnection();
        }
    }
    
    /**
     * CLIENTES 
     */
    
    public int insertarCliente(String ruc, String nombre, String dir) throws SQLException {
        this.Conectar();
        String sql = "INSERT INTO cliente(ruc_cliente,nom_cliente,direccion_cliente) VALUES (?,?,?)";
        PreparedStatement statement = con.prepareStatement(sql);
        statement.setString(1, ruc);
        statement.setString(2, nombre);
        statement.setString(3, dir);
        int rowsInserted = statement.executeUpdate();
        if (rowsInserted > 0) {
            return 1;
        }else{
            return 0;
        }
    }
    
    public int eliminarCliente(int id) throws SQLException {
        this.Conectar();
        String sql = "DELETE FROM cliente WHERE id_cliente=?";
        PreparedStatement statement = con.prepareStatement(sql);
        statement.setInt(1, id);
        int rowsDeleted = statement.executeUpdate();
        if (rowsDeleted > 0) {
            return 1;
        }else{
            return 0;
        }
    }
    
    public int actualizarCliente(int id,String ruc, String nombre, String dir) throws SQLException {
        this.Conectar();
        String sql = "UPDATE cliente SET ruc_cliente=?,nombre_cliente=?,direccion_cliente=? WHERE id_cliente=?";
        PreparedStatement statement = con.prepareStatement(sql);
        statement.setString(1, ruc);
        statement.setString(2, nombre);
        statement.setString(3, dir);
        statement.setInt(4,id);
        int rowsUpdated = statement.executeUpdate();
        if (rowsUpdated > 0) {
            return 1;
        }else{
            return 0;
        }
    }
    
    public ArrayList<Cliente> listarClienteOrc() throws SQLException {
        this.Conectar();
        ArrayList<Cliente> clientes = new ArrayList<>();
        String sql = "SELECT * FROM cliente";
        Statement statement = con.createStatement();
        ResultSet result = statement.executeQuery(sql);
        while (result.next()) {
            int codigo = result.getInt(1);
            String ruc = result.getString(2);
            String nombre = result.getString(3);
            String direccion = result.getString(4);

            Cliente cli = new Cliente();

            cli.setId(codigo);
            cli.setRuc(ruc);
            cli.setName(nombre);
            cli.setAddress(direccion);

            clientes.add(cli);
        }
        return clientes;
    }
    
    public Cliente buscarCliente(String ruc) throws SQLException {
        this.Conectar();
        Cliente clienteBuscar = new Cliente();
        String sql = "SELECT * FROM cliente WHERE ruc_cliente=?";
        PreparedStatement statement = con.prepareStatement(sql);
        statement.setString(1, ruc);
        ResultSet result = statement.executeQuery();
        while (result.next()) {
            int codigoR = result.getInt(1);
            String rucR = result.getString(2);
            String nombreR = result.getString(3);
            String direccionR = result.getString(4);

            clienteBuscar.setId(codigoR);
            clienteBuscar.setRuc(rucR);
            clienteBuscar.setName(nombreR);
            clienteBuscar.setAddress(direccionR);
        }
        return clienteBuscar;
    }
    
    /**
     * CIUDAD
     */
    
    
    
    
    /**
     * CABECERA FACTURA
     */
    
    /**
     * DETALLE FACTURA 
     */
    
    /**
     * REPORTE 
     */
    
    /**
     * NO CONTABLES
     */
}
