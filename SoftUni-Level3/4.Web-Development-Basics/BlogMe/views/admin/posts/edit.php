<div class="container">
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <form method="post" role="form">
                <div class="form-group">
                    <label for="title">Title: </label>
                    <input type="text" id="title" class="form-control" required name="title"
                           value="<?php if( isset( $this -> formValues['title'] ) ) {
                                            echo( $this -> getFieldValue('title') );
                                        } else {
                                            echo htmlspecialchars($this -> post['Title']);
                                        }
                                  ?>"/>
                    <?php if( isset( $this -> validationErrors['title'] ) ) {
                        echo $this -> getValidationError('title');
                    } ?>
                    <label for="content">Content: </label>
                        <textarea id="content" rows="12" class="form-control" required name="content"><?php
                        if( isset( $this -> formValues['content'] ) ) {
                            echo($this -> getFieldValue('content'));
                        } else {
                            echo htmlspecialchars($this -> post['Content']);
                        }?></textarea>
                    <?php if( isset( $this -> validationErrors['content'] ) ) {
                        echo  $this -> getValidationError('content');
                    }
                    ?>
                    <label for="tags">Tags (separated by comma): </label>
<!--                    --><?php //var_dump($this -> post);  var_dump($this -> tags); ?>
                    <input type="text" id="tags" class="form-control" required name="tags"
                           value="<?php
                           if( isset( $this -> formValues['tags'] ) ) {
                               echo( $this -> getFieldValue('tags') );
                           } else {
                               foreach($this -> tags as $tag) {
                                   echo htmlspecialchars($tag['Name']);
                               }
                           }
                           ?>"/>
                    <?php
                    if( isset( $this -> validationErrors['tags'] ) ) {
                        echo $this -> getValidationError('tags');
                    }
                    ?>
                    <br />
                    <input type="submit" value="Edit" class="btn btn-primary" />
                </div>
            </form>
        </div>
    </div>