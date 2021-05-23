import React from 'react';
import { useSearchParams, useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';

type FormData = {
    search: string;
  };

export const UniversitySearch = () => {
    const { register, handleSubmit } = useForm<FormData>();
    const [searchParams] = useSearchParams();
    const criteria = searchParams.get('criteria') || '';
    const navigate = useNavigate();
    const submitForm = ({ search }: FormData) => {
      if (search == null || search.trim() === '')
        navigate(`/Universities`);
      else navigate(`/Universities/search?criteria=${search}`);
    };
  
    return (
        <div>
            <form onSubmit={handleSubmit(submitForm)}>
            <input       
                type="text"
                placeholder="Search..."
                defaultValue={criteria}
                {...register('search')}
            />
            </form>
        </div>
    );
  };