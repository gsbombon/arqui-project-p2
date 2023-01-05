
package model;


public class User {
    private String usuario;
    private String pass;

    public User(String usuario, String pass) {
        this.usuario = usuario;
        this.pass = pass;
    }

    public User() {
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
    
    
}
