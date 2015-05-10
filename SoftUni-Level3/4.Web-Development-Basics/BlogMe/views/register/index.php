<br />
<br />
<div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
        <?php if( ! empty($this -> registration_message) ): ?>
            <div class="alert alert-danger error" role="alert"><?php echo $this -> registration_message ?></div>
        <?php endif; ?>
    </div>
</div>
<div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
        <div class="well">
            <form method="POST">
                <label for="username">Username:</label>
                <input type="text" id="username" required name="username" class="form-control" />
                <br />
                <label for="password">Password:</label>
                <input type="password" id="password" required name="password" class="form-control" />
                <br />
                <label for="passwordConfirmed">Confirm Password:</label>
                <input type="password" id="passwordConfirmed" required name="passwordConfirmed" class="form-control" />
                <br />
                <label for="fullName">Full Name (optional): </label>
                <input type="text" id="fullName" name="fullName" class="form-control" />
                <br />
                <label for="email">Email: </label>
                <input type="text" id="email" required name="email" class="form-control" />
                <br />
                <input type="submit" name="submit" value="Register" class="btn btn-default" />
            </form>
        </div>
    </div>
</div>