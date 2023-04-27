import React, { useState } from "react";

const AuthorForm = ({ authorname, formSubmit, formErrors }) => {
  console.log(authorname)
  const [name, setName] = useState(authorname.name);


  const handleSubmit = (e) => {
    e.preventDefault();

    formSubmit({
      name,
    });
  };
  return (
    <form onSubmit={handleSubmit}>
      <p>
        Authors Name:
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        
        { formErrors && formErrors.map((err, index) => <p className="error" key={index}>{err}</p>) }
      </p>
      <button>submit</button>
    </form>
  );
};

export default AuthorForm;
