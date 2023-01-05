
package controller;

import connection.Login_connection;
import java.sql.SQLException;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

@ManagedBean()
@SessionScoped
public class login_controller {
    
    Login_connection lc = new Login_connection();
    private String usuario = "";
    private String pass = "";
    private String mensaje = "";

    public login_controller() {
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getPass() {
        return pass;
    }

    public void setPass(String pass) {
        this.pass = pass;
    }

    public String getMensaje() {
        return mensaje;
    }

    public void setMensaje(String mensaje) {
        this.mensaje = mensaje;
    }
    
    public String ingresar() throws SQLException {
        if (lc.loginOrc(usuario, pass) == 1) {
            return "/viewMain.xhtml?faces-redirect=true";
        } else {
            mensaje = "Usuario/Contraseña Incorrectas";
            return "/viewLogin.xhtml?faces-redirect=true";
        }
    }
    
    public void limpiarForm(){
        this.pass="";
        this.usuario="";
    }

    public void crearUsuario() {
        int resultado;
        try {
            resultado = lc.insertarUsuarioOrc(usuario, pass);
            if (resultado == 1) {
                mensaje = "Usuario creado correctamente !";
                this.limpiarForm();
            } else {
                mensaje = "No se pudo crear";
            }
        } catch (Exception ex) {
            mensaje = "No se pudo crear";
        }
    }
}
