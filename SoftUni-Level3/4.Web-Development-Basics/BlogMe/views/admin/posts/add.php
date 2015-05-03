<form method="post">
    <p>
        <label for="title">Title: </label>
        <input type="text" id="title" required name="title"
               value="<?php if( isset( $this -> formValues['title'] ) ) {
                                echo( $this -> getFieldValue('title') );
                             }
                       ?>"/>
        <?php if( isset( $this -> validationErrors['title'] ) ) {
            echo $this -> getValidationError('title');
        } ?>
    </p>
    <p>
        <label for="content">Content: </label>
        <input type="text" id="content" required name="content"
            value="<?php if( isset( $this -> formValues['content'] ) ) {
                            echo( $this -> getFieldValue('content') );
                         }
                   ?>"/>
        <?php if( isset( $this -> validationErrors['content'] ) ) {
            echo  $this -> getValidationError('content');
        } ?>
    </p>
    <p>
        <label for="tags">Tags(separated by comma): </label>
        <input type="text" id="tags" required name="tags"
               value="<?php if( isset( $this -> formValues['tags'] ) ) {
                                echo( $this -> getFieldValue('tags') );
                            }
                      ?>"/>
        <?php if( isset( $this -> validationErrors['tags'] ) ) {
            echo $this -> getValidationError('tags');
        } ?>
    </p>
    <input type="submit" value="Submit" />
</form>