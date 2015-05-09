<div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
    <?php if( ! empty($this -> login_message) ): ?>
            <div class="alert alert-danger error" role="alert"><?php echo $this -> login_message ?></div>
    <?php endif; ?>
    </div>
</div>
<div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
        <div class="well">
            <form method="POST">
                <label for="username">Username:</label>
                <input type="text" id="username" name="username" class="form-control" />
                <label for="password">Password:</label>
                <input type="password" id="password" name="password" class="form-control" />
                <br />
                <input type="submit" name="submit" value="Login" class="btn btn-default" />
            </form>
        </div>
    </div>
</div>