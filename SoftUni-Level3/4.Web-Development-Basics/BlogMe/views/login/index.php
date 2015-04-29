<?php if( empty ($this -> logged_user)): ?>
<form method="POST">
    <p>
        Username:
        <input type="text" name="username" />
    </p>
    <p>
        Password:
        <input type="password" name="password" />
    </p>
    <p>
        <input type="submit" name="submit" value="Login" />
    </p>
</form>
<?php endif; ?>